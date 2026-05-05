# Сборка (SDK образ)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
# Переменные сборки Configuration=Release
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Копируем только csproj для кэширования NuGet-пакетов
COPY ["Museum.Paleontology.csproj", "./"]
RUN dotnet restore "./Museum.Paleontology.csproj"

# Копируем весь исходный код
COPY . .
WORKDIR "/src/."

# Компилируем в режиме Release
RUN dotnet build "./Museum.Paleontology.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Публикация
FROM build AS publish
RUN dotnet publish "./Museum.Paleontology.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Подготовка образа к запуску
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Копируем готовые файлы из этапа публикации
COPY --from=publish /app/publish .

# Порт приложения (18 - номер по списку группы, берём по модулю 10 = 08)
ENV ASPNETCORE_URLS=http://+:8008
EXPOSE 8008

# Запуск
ENTRYPOINT ["dotnet", "Museum.Paleontology.dll"]

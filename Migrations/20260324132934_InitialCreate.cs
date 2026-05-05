using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Museum.Paleontology.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LatinName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CommonName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Era = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fossils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscoveryDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    CollectionId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpeciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fossils", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fossils_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fossils_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Fossils_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Фоссилии динозавров", "Динозавры Мезозоя" },
                    { 2, "Ранние млекопитающие", "Млекопитающие Палеогена" },
                    { 3, "Ихтиозавры, плезиозавры, крокодилы", "Морские Рептилии" },
                    { 4, "Переходные формы", "Археоптерикс и Ранние Птицы" },
                    { 5, "Трилобиты, кораллы, древние рыбы", "Палеозойские Окаменелости" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Notes", "RoomNumber" },
                values: new object[,]
                {
                    { 1, "Динозавры", "Зал 2" },
                    { 2, "Млекопитающие", "Зал 4" },
                    { 3, "Морские рептилии", "Зал 3" },
                    { 4, "Археоптерикс", "Зал 1" },
                    { 5, "Палеозой", "Зал 5" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "CommonName", "Era", "LatinName" },
                values: new object[,]
                {
                    { 1, "Тираннозавр", "Поздний мел", "Tyrannosaurus rex" },
                    { 2, "Трицератопс", "Поздний мел", "Triceratops horridus" },
                    { 3, "Саблезубый кот", "Плейстоцен", "Smilodon fatalis" },
                    { 4, "Ихтиозавр", "Ранняя юра", "Ichthyosaurus communis" },
                    { 5, "Плезиозавр", "Ранняя юра", "Plesiosaurus dolichodeirus" },
                    { 6, "Археоптерикс", "Поздняя юра", "Archaeopteryx lithographica" },
                    { 7, "Стегозавр", "Поздняя юра", "Stegosaurus armatus" },
                    { 8, "Велоцираптор", "Поздний мел", "Velociraptor mongoliensis" },
                    { 9, "Анкилозавр", "Поздний мел", "Ankylosaurus magniventris" },
                    { 10, "Брахиозавр", "Поздняя юра", "Brachiosaurus altithorax" },
                    { 11, "Дейноних", "Ранняя мел", "Deinonychus antirrhopus" },
                    { 12, "Спинозавр", "Поздний мел", "Spinosaurus aegyptiacus" },
                    { 13, "Аллозавр", "Поздняя юра", "Allosaurus fragilis" },
                    { 14, "Мегалозавр", "Средняя юра", "Megalosaurus bucklandii" },
                    { 15, "Гиганотозавр", "Поздний мел", "Giganotosaurus carolinii" },
                    { 16, "Диплодок", "Поздняя юра", "Diplodocus carnegii" },
                    { 17, "Компсогнат", "Поздняя юра", "Compsognathus longipes" },
                    { 18, "Платеозавр", "Поздний триас", "Plateosaurus engelhardti" },
                    { 19, "Диметродон", "Ранний пермь", "Dimetrodon grandis" },
                    { 20, "Тилакосмил", "Поздний Миоцен - Ранний Плиоцен", "Thylacosmilus atrox" },
                    { 21, "Мозазавр", "Поздний мел", "Mosasaurus hoffmannii" },
                    { 22, "Эласмозавр", "Поздний мел", "Elasmosaurus platyurus" },
                    { 23, "Лиоплевродон", "Средняя юра", "Liopleurodon ferox" },
                    { 24, "Нотозавр", "Ранний триас", "Nothosaurus giganteus" },
                    { 25, "Ксифактинус", "Поздний мел", "Xiphactinus audax" },
                    { 26, "Дунклеостеус", "Поздний девон", "Dunkleosteus terrelli" },
                    { 27, "Ортакантус", "Каменноугольный - Пермский", "Orthacanthus compressus" },
                    { 28, "Эвриптерид", "Силурий", "Eurypterid" },
                    { 29, "Трилобит", "Кембрий - Пермский", "Trilobita" },
                    { 30, "Аммонит", "Девон - Мел", "Ammonite" },
                    { 31, "Сауропозейдон", "Поздний мел", "Sauroposeidon proteles" }
                });

            migrationBuilder.InsertData(
                table: "Fossils",
                columns: new[] { "Id", "CollectionId", "Description", "DiscoveryDate", "LocationId", "Name", "SpeciesId" },
                values: new object[,]
                {
                    { 1, 1, "Найден в Монтане", new DateTime(1902, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Череп Тираннозавра", 1 },
                    { 2, 1, "Полный череп", new DateTime(1889, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Череп Трицератопса", 2 },
                    { 3, 2, "Из Лос-Анджелеса", new DateTime(1912, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Клы саблезубого", 3 },
                    { 4, 3, "Полный скелет, отличная сохранность", new DateTime(1821, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Скелет Ихтиозавра", 4 },
                    { 5, 3, "Один из первых найденных", new DateTime(1821, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Скелет Плезиозавра", 5 },
                    { 6, 4, "Доказательство эволции птиц", new DateTime(1861, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Перохеоптерикса", 6 },
                    { 7, 1, "Полный набор пластин", new DateTime(1877, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Панцирь Стегозавра", 7 },
                    { 8, 1, "Один из первых находок в Монголии", new DateTime(1924, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Коготь Велоцираптора", 8 },
                    { 9, 1, "Сохранённый череп с костяным шлемом", new DateTime(1908, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Череп Анкилозавра", 9 },
                    { 10, 1, "Огромный позвонок", new DateTime(1903, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Позвонок Брахиозавра", 10 },
                    { 11, 1, "Характерный изогнутый коготь", new DateTime(1964, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Коготь Дейнониха", 11 },
                    { 12, 1, "Длинный конический зуб", new DateTime(1912, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Зуб Спинозавра", 12 },
                    { 13, 1, "Хорошо сохранившаяся кость", new DateTime(1877, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Череп Аллозавра", 13 },
                    { 14, 1, "Первый описанный динозавр", new DateTime(1676, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Череп Мегалозавра", 14 },
                    { 15, 1, "Сравнение с тираннозавром", new DateTime(1993, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Зуб Гиганотозавра", 15 },
                    { 16, 1, "Длинный шейный позвонок", new DateTime(1877, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Шейный позвонок Диплодока", 16 },
                    { 17, 1, "Маленький хищник", new DateTime(1859, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Скелет Компсогната", 17 },
                    { 18, 1, "Часть скелета раннего динозавра", new DateTime(1834, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Позвонок Платеозавра", 18 },
                    { 19, 5, "Характерный парус на спине", new DateTime(1878, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Парус Диметродона", 19 },
                    { 20, 2, "Длинные когти и зубы", new DateTime(1926, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Клы Тилакосмила", 20 },
                    { 21, 3, "Крупный морской рептилий", new DateTime(1780, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Череп Мозазавра", 21 },
                    { 22, 3, "Очень длинная шея", new DateTime(1868, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Шея Эласмозавра", 22 },
                    { 23, 3, "Массивный зуб хищника", new DateTime(1873, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Зуб Лиоплевродона", 23 },
                    { 24, 3, "Ранний морской рептилий", new DateTime(1834, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Скелет Нотозавра", 24 },
                    { 25, 3, "Крупная хищная рыба", new DateTime(1870, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Скелет Ксифактинуса", 25 },
                    { 26, 5, "Массивная бронированная рыба", new DateTime(1867, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Голова Дунклеостеуса", 26 },
                    { 27, 3, "Длинный шип на позвоночнике", new DateTime(1837, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Позвонок Ортаканта", 27 },
                    { 28, 5, "Морской скорпион", new DateTime(1822, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Эвриптерид", 28 },
                    { 29, 5, "Обычная форма палеозоя", new DateTime(1824, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Трилобит", 29 },
                    { 30, 5, "Спиральный моллюск", new DateTime(1804, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Аммонит", 30 },
                    { 31, 1, "Один из самых высоких динозавров", new DateTime(1994, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Скелет Сауропозейдона", 31 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_Name",
                table: "Collections",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fossils_CollectionId",
                table: "Fossils",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fossils_LocationId",
                table: "Fossils",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Fossils_SpeciesId",
                table: "Fossils",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fossils");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}

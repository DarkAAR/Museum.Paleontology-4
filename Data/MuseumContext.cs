using Microsoft.EntityFrameworkCore;
using Museum.Paleontology.Models;

namespace Museum.Paleontology.Data;

public class MuseumContext : DbContext
{
    public MuseumContext() { }
    public MuseumContext(DbContextOptions<MuseumContext> options) : base(options) { }

    public DbSet<Fossil> Fossils { get; set; } = null!;
    public DbSet<Collection> Collections { get; set; } = null!;
    public DbSet<Species> Species { get; set; } = null!;
    public DbSet<Location> Locations { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var dbPath = Path.Join(AppContext.BaseDirectory, "paleontology.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Collection>()
            .HasIndex(c => c.Name)
            .IsUnique();

        modelBuilder.Entity<Collection>().HasData(
            new Collection { Id = 1, Name = "Динозавры Мезозоя", Description = "Фоссилии динозавров" },
            new Collection { Id = 2, Name = "Млекопитающие Палеогена", Description = "Ранние млекопитающие" },
            new Collection { Id = 3, Name = "Морские Рептилии", Description = "Ихтиозавры, плезиозавры, крокодилы" },
            new Collection { Id = 4, Name = "Археоптерикс и Ранние Птицы", Description = "Переходные формы" },
            new Collection { Id = 5, Name = "Палеозойские Окаменелости", Description = "Трилобиты, кораллы, древние рыбы" }
        );

        modelBuilder.Entity<Species>().HasData(
            new Species { Id = 1, LatinName = "Tyrannosaurus rex", CommonName = "Тираннозавр", Era = "Поздний мел" },
            new Species { Id = 2, LatinName = "Triceratops horridus", CommonName = "Трицератопс", Era = "Поздний мел" },
            new Species { Id = 3, LatinName = "Smilodon fatalis", CommonName = "Саблезубый кот", Era = "Плейстоцен" },
            new Species { Id = 4, LatinName = "Ichthyosaurus communis", CommonName = "Ихтиозавр", Era = "Ранняя юра" },
            new Species { Id = 5, LatinName = "Plesiosaurus dolichodeirus", CommonName = "Плезиозавр", Era = "Ранняя юра" },
            new Species { Id = 6, LatinName = "Archaeopteryx lithographica", CommonName = "Археоптерикс", Era = "Поздняя юра" },
            new Species { Id = 7, LatinName = "Stegosaurus armatus", CommonName = "Стегозавр", Era = "Поздняя юра" },
            new Species { Id = 8, LatinName = "Velociraptor mongoliensis", CommonName = "Велоцираптор", Era = "Поздний мел" },
            new Species { Id = 9, LatinName = "Ankylosaurus magniventris", CommonName = "Анкилозавр", Era = "Поздний мел" },
            new Species { Id = 10, LatinName = "Brachiosaurus altithorax", CommonName = "Брахиозавр", Era = "Поздняя юра" },
            new Species { Id = 11, LatinName = "Deinonychus antirrhopus", CommonName = "Дейноних", Era = "Ранняя мел" },
            new Species { Id = 12, LatinName = "Spinosaurus aegyptiacus", CommonName = "Спинозавр", Era = "Поздний мел" },
            new Species { Id = 13, LatinName = "Allosaurus fragilis", CommonName = "Аллозавр", Era = "Поздняя юра" },
            new Species { Id = 14, LatinName = "Megalosaurus bucklandii", CommonName = "Мегалозавр", Era = "Средняя юра" },
            new Species { Id = 15, LatinName = "Giganotosaurus carolinii", CommonName = "Гиганотозавр", Era = "Поздний мел" },
            new Species { Id = 16, LatinName = "Diplodocus carnegii", CommonName = "Диплодок", Era = "Поздняя юра" },
            new Species { Id = 17, LatinName = "Compsognathus longipes", CommonName = "Компсогнат", Era = "Поздняя юра" },
            new Species { Id = 18, LatinName = "Plateosaurus engelhardti", CommonName = "Платеозавр", Era = "Поздний триас" },
            new Species { Id = 19, LatinName = "Dimetrodon grandis", CommonName = "Диметродон", Era = "Ранний пермь" },
            new Species { Id = 20, LatinName = "Thylacosmilus atrox", CommonName = "Тилакосмил", Era = "Поздний Миоцен - Ранний Плиоцен" },
            new Species { Id = 21, LatinName = "Mosasaurus hoffmannii", CommonName = "Мозазавр", Era = "Поздний мел" },
            new Species { Id = 22, LatinName = "Elasmosaurus platyurus", CommonName = "Эласмозавр", Era = "Поздний мел" },
            new Species { Id = 23, LatinName = "Liopleurodon ferox", CommonName = "Лиоплевродон", Era = "Средняя юра" },
            new Species { Id = 24, LatinName = "Nothosaurus giganteus", CommonName = "Нотозавр", Era = "Ранний триас" },
            new Species { Id = 25, LatinName = "Xiphactinus audax", CommonName = "Ксифактинус", Era = "Поздний мел" },
            new Species { Id = 26, LatinName = "Dunkleosteus terrelli", CommonName = "Дунклеостеус", Era = "Поздний девон" },
            new Species { Id = 27, LatinName = "Orthacanthus compressus", CommonName = "Ортакантус", Era = "Каменноугольный - Пермский" },
            new Species { Id = 28, LatinName = "Eurypterid", CommonName = "Эвриптерид", Era = "Силурий" },
            new Species { Id = 29, LatinName = "Trilobita", CommonName = "Трилобит", Era = "Кембрий - Пермский" },
            new Species { Id = 30, LatinName = "Ammonite", CommonName = "Аммонит", Era = "Девон - Мел" },
            new Species { Id = 31, LatinName = "Sauroposeidon proteles", CommonName = "Сауропозейдон", Era = "Поздний мел" }
        );

        modelBuilder.Entity<Location>().HasData(
            new Location { Id = 1, RoomNumber = "Зал 2", Notes = "Динозавры" },
            new Location { Id = 2, RoomNumber = "Зал 4", Notes = "Млекопитающие" },
            new Location { Id = 3, RoomNumber = "Зал 3", Notes = "Морские рептилии" },
            new Location { Id = 4, RoomNumber = "Зал 1", Notes = "Археоптерикс" },
            new Location { Id = 5, RoomNumber = "Зал 5", Notes = "Палеозой" }
        );

        modelBuilder.Entity<Fossil>().HasData(
            new Fossil { Id = 1, Name = "Череп Тираннозавра", Description = "Найден в Монтане", DiscoveryDate = new DateTime(1902, 8, 12), CollectionId = 1, SpeciesId = 1, LocationId = 1 },
            new Fossil { Id = 2, Name = "Череп Трицератопса", Description = "Полный череп", DiscoveryDate = new DateTime(1889, 1, 1), CollectionId = 1, SpeciesId = 2, LocationId = 1 },
            new Fossil { Id = 3, Name = "Клы саблезубого", Description = "Из Лос-Анджелеса", DiscoveryDate = new DateTime(1912, 5, 20), CollectionId = 2, SpeciesId = 3, LocationId = 2 },
            new Fossil { Id = 4, Name = "Скелет Ихтиозавра", Description = "Полный скелет, отличная сохранность", DiscoveryDate = new DateTime(1821, 3, 10), CollectionId = 3, SpeciesId = 4, LocationId = 3 },
            new Fossil { Id = 5, Name = "Скелет Плезиозавра", Description = "Один из первых найденных", DiscoveryDate = new DateTime(1821, 11, 24), CollectionId = 3, SpeciesId = 5, LocationId = 3 },
            new Fossil { Id = 6, Name = "Перохеоптерикса", Description = "Доказательство эволции птиц", DiscoveryDate = new DateTime(1861, 8, 15), CollectionId = 4, SpeciesId = 6, LocationId = 4 },
            new Fossil { Id = 7, Name = "Панцирь Стегозавра", Description = "Полный набор пластин", DiscoveryDate = new DateTime(1877, 7, 1), CollectionId = 1, SpeciesId = 7, LocationId = 1 },
            new Fossil { Id = 8, Name = "Коготь Велоцираптора", Description = "Один из первых находок в Монголии", DiscoveryDate = new DateTime(1924, 6, 1), CollectionId = 1, SpeciesId = 8, LocationId = 1 },
            new Fossil { Id = 9, Name = "Череп Анкилозавра", Description = "Сохранённый череп с костяным шлемом", DiscoveryDate = new DateTime(1908, 5, 14), CollectionId = 1, SpeciesId = 9, LocationId = 1 },
            new Fossil { Id = 10, Name = "Позвонок Брахиозавра", Description = "Огромный позвонок", DiscoveryDate = new DateTime(1903, 4, 9), CollectionId = 1, SpeciesId = 10, LocationId = 1 },
            new Fossil { Id = 11, Name = "Коготь Дейнониха", Description = "Характерный изогнутый коготь", DiscoveryDate = new DateTime(1964, 9, 12), CollectionId = 1, SpeciesId = 11, LocationId = 1 },
            new Fossil { Id = 12, Name = "Зуб Спинозавра", Description = "Длинный конический зуб", DiscoveryDate = new DateTime(1912, 2, 28), CollectionId = 1, SpeciesId = 12, LocationId = 1 },
            new Fossil { Id = 13, Name = "Череп Аллозавра", Description = "Хорошо сохранившаяся кость", DiscoveryDate = new DateTime(1877, 8, 22), CollectionId = 1, SpeciesId = 13, LocationId = 1 },
            new Fossil { Id = 14, Name = "Череп Мегалозавра", Description = "Первый описанный динозавр", DiscoveryDate = new DateTime(1676, 12, 1), CollectionId = 1, SpeciesId = 14, LocationId = 1 },
            new Fossil { Id = 15, Name = "Зуб Гиганотозавра", Description = "Сравнение с тираннозавром", DiscoveryDate = new DateTime(1993, 11, 15), CollectionId = 1, SpeciesId = 15, LocationId = 1 },
            new Fossil { Id = 16, Name = "Шейный позвонок Диплодока", Description = "Длинный шейный позвонок", DiscoveryDate = new DateTime(1877, 10, 10), CollectionId = 1, SpeciesId = 16, LocationId = 1 },
            new Fossil { Id = 17, Name = "Скелет Компсогната", Description = "Маленький хищник", DiscoveryDate = new DateTime(1859, 7, 1), CollectionId = 1, SpeciesId = 17, LocationId = 1 },
            new Fossil { Id = 18, Name = "Позвонок Платеозавра", Description = "Часть скелета раннего динозавра", DiscoveryDate = new DateTime(1834, 9, 20), CollectionId = 1, SpeciesId = 18, LocationId = 1 },
            new Fossil { Id = 19, Name = "Парус Диметродона", Description = "Характерный парус на спине", DiscoveryDate = new DateTime(1878, 1, 1), CollectionId = 5, SpeciesId = 19, LocationId = 5 },
            new Fossil { Id = 20, Name = "Клы Тилакосмила", Description = "Длинные когти и зубы", DiscoveryDate = new DateTime(1926, 4, 5), CollectionId = 2, SpeciesId = 20, LocationId = 2 },
            new Fossil { Id = 21, Name = "Череп Мозазавра", Description = "Крупный морской рептилий", DiscoveryDate = new DateTime(1780, 10, 10), CollectionId = 3, SpeciesId = 21, LocationId = 3 },
            new Fossil { Id = 22, Name = "Шея Эласмозавра", Description = "Очень длинная шея", DiscoveryDate = new DateTime(1868, 3, 18), CollectionId = 3, SpeciesId = 22, LocationId = 3 },
            new Fossil { Id = 23, Name = "Зуб Лиоплевродона", Description = "Массивный зуб хищника", DiscoveryDate = new DateTime(1873, 6, 5), CollectionId = 3, SpeciesId = 23, LocationId = 3 },
            new Fossil { Id = 24, Name = "Скелет Нотозавра", Description = "Ранний морской рептилий", DiscoveryDate = new DateTime(1834, 8, 12), CollectionId = 3, SpeciesId = 24, LocationId = 3 },
            new Fossil { Id = 25, Name = "Скелет Ксифактинуса", Description = "Крупная хищная рыба", DiscoveryDate = new DateTime(1870, 1, 1), CollectionId = 3, SpeciesId = 25, LocationId = 3 },
            new Fossil { Id = 26, Name = "Голова Дунклеостеуса", Description = "Массивная бронированная рыба", DiscoveryDate = new DateTime(1867, 5, 15), CollectionId = 5, SpeciesId = 26, LocationId = 5 },
            new Fossil { Id = 27, Name = "Позвонок Ортаканта", Description = "Длинный шип на позвоночнике", DiscoveryDate = new DateTime(1837, 7, 20), CollectionId = 3, SpeciesId = 27, LocationId = 3 },
            new Fossil { Id = 28, Name = "Эвриптерид", Description = "Морской скорпион", DiscoveryDate = new DateTime(1822, 10, 30), CollectionId = 5, SpeciesId = 28, LocationId = 5 },
            new Fossil { Id = 29, Name = "Трилобит", Description = "Обычная форма палеозоя", DiscoveryDate = new DateTime(1824, 9, 5), CollectionId = 5, SpeciesId = 29, LocationId = 5 },
            new Fossil { Id = 30, Name = "Аммонит", Description = "Спиральный моллюск", DiscoveryDate = new DateTime(1804, 11, 12), CollectionId = 5, SpeciesId = 30, LocationId = 5 },
            new Fossil { Id = 31, Name = "Скелет Сауропозейдона", Description = "Один из самых высоких динозавров", DiscoveryDate = new DateTime(1994, 6, 1), CollectionId = 1, SpeciesId = 31, LocationId = 1 }
        );

        modelBuilder.Entity<Fossil>()
            .HasOne(f => f.Collection)
            .WithMany(c => c.Fossils)
            .HasForeignKey(f => f.CollectionId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Fossil>()
            .HasOne(f => f.Species)
            .WithMany(s => s.Fossils)
            .HasForeignKey(f => f.SpeciesId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Fossil>()
            .HasOne(f => f.Location)
            .WithMany()
            .HasForeignKey(f => f.LocationId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
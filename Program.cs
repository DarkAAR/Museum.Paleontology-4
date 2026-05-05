using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;
using Museum.Paleontology.Data;
using Museum.Paleontology.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MuseumContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddTransient<IFossilService, FossilService>();
builder.Services.AddSingleton<IMuseumService, MuseumService>();

var app = builder.Build();

// Главная страница
app.MapGet("/", () => Results.Content(@"
<!DOCTYPE html>
<html>
<head><title>Museum Paleontology API</title></head>
<body>
<h1>Museum Paleontology API</h1>
<h2>GET Endpoints:</h2>
<ul>
    <li><a href='/api/fossils'>/api/fossils</a> - Все окаменелости</li>
    <li><a href='/api/fossils/1'>/api/fossils/{id}</a> - Окаменелость по ID</li>
    <li><a href='/api/fossils/statistics'>/api/fossils/statistics</a> - Статистика</li>
    <li><a href='/api/collections'>/api/collections</a> - Коллекции</li>
    <li><a href='/api/locations'>/api/locations</a> - Залы</li>
    <li><a href='/api/museum/info'>/api/museum/info</a> - Информация о музее</li>
    <li><a href='/api/config'>/api/config</a> - Конфигурация приложения</li>
</ul>
</body>
</html>", "text/html; charset=utf-8"));

// GET /api/fossils - Все окаменелости
app.MapGet("/api/fossils", async (MuseumContext db) =>
{
    var fossils = await db.Fossils
        .Include(f => f.Species)
        .Include(f => f.Collection)
        .Include(f => f.Location)
        .Select(f => new
        {
            f.Id,
            f.Name,
            f.Description,
            f.DiscoveryDate,
            Species = new
            {
                f.Species.LatinName,
                f.Species.CommonName,
                f.Species.Era
            },
            Collection = new
            {
                f.Collection.Name,
                f.Collection.Description
            },
            Location = new
            {
                f.Location.RoomNumber,
                f.Location.Notes
            }
        })
        .ToListAsync();

    return Results.Ok(fossils);
});

// GET /api/fossils/{id} - Одна окаменелость по ID
app.MapGet("/api/fossils/{id}", async (MuseumContext db, int id) =>
{
    var fossil = await db.Fossils
        .Include(f => f.Species)
        .Include(f => f.Collection)
        .Include(f => f.Location)
        .Where(f => f.Id == id)
        .Select(f => new
        {
            f.Id,
            f.Name,
            f.Description,
            f.DiscoveryDate,
            Species = new
            {
                f.Species.LatinName,
                f.Species.CommonName,
                f.Species.Era
            },
            Collection = new
            {
                f.Collection.Name,
                f.Collection.Description
            },
            Location = new
            {
                f.Location.RoomNumber,
                f.Location.Notes
            }
        })
        .FirstOrDefaultAsync();

    if (fossil is null)
        return Results.NotFound(new { Error = $"Окаменелость с ID {id} не найдена" });

    return Results.Ok(fossil);
});

// GET /api/fossils/statistics - Статистика
app.MapGet("/api/fossils/statistics", async (MuseumContext db, IFossilService fossilService) =>
{
    var fossils = await db.Fossils.ToListAsync();
    var statistics = fossilService.GetStatistics(fossils);
    return Results.Ok(statistics);
});

// GET /api/collections - Все коллекции
app.MapGet("/api/collections", async (MuseumContext db) =>
{
    var collections = await db.Collections
        .Select(c => new
        {
            c.Name,
            c.Description
        })
        .ToListAsync();

    return Results.Ok(collections);
});

// GET /api/locations - Все залы
app.MapGet("/api/locations", async (MuseumContext db) =>
{
    var locations = await db.Locations.ToListAsync();
    return Results.Ok(locations);
});

// GET /api/museum/info - Информация о музее
app.MapGet("/api/museum/info", async (MuseumContext db, IMuseumService museumService) =>
{
    var fossils = await db.Fossils.Include(f => f.Species).ToListAsync();
    var collections = await db.Collections.ToListAsync();
    var species = await db.Species.ToListAsync();
    var locations = await db.Locations.ToListAsync();

    var museumInfo = museumService.GetMuseumInfo(fossils, collections, species, locations);
    return Results.Ok(museumInfo);
});

// GET /api/config - Конфигурация приложения
app.MapGet("/api/config", (IConfiguration config) =>
{
    return Results.Json(new
    {
        AppName = config["AppSettings:AppName"],
        Version = config["AppSettings:Version"],
        MaxItems = int.Parse(config["AppSettings:MaxItems"] ?? "100"),
        ConnectionString = config.GetConnectionString("DefaultConnection")
    });
});

app.Run();
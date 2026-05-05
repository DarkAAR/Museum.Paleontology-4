using Museum.Paleontology.DTOs;
using Museum.Paleontology.Models;

namespace Museum.Paleontology.Services;
public class MuseumService : IMuseumService
{
    private readonly IConfiguration _configuration;

    public MuseumService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public MuseumInfoDto GetMuseumInfo(
        IEnumerable<Fossil> fossils,
        IEnumerable<Collection> collections,
        IEnumerable<Species> species,
        IEnumerable<Location> locations)
    {
        var fossilList = fossils.ToList();

        var name = _configuration["MuseumSettings:Name"];
        var sphere = _configuration["MuseumSettings:Sphere"];
        var description = _configuration["MuseumSettings:Description"];

        var totalFossils = fossilList.Count;
        var totalCollections = collections.Count();
        var totalSpecies = species.Count();
        var totalLocations = locations.Count();

        var eraGroups = fossilList
            .Where(f => f.Species?.Era != null)
            .GroupBy(f => f.Species!.Era)
            .OrderByDescending(g => g.Count())
            .FirstOrDefault();

        var dates = fossilList
            .Where(f => f.DiscoveryDate.HasValue)
            .Select(f => f.DiscoveryDate!.Value)
            .ToList();

        return new MuseumInfoDto
        {
            MuseumName = name,
            Sphere = sphere,
            Description = description,
            TotalFossils = totalFossils,
            TotalCollections = totalCollections,
            TotalSpecies = totalSpecies,
            TotalLocations = totalLocations,
            MostCommonEra = eraGroups?.Key ?? "Не определена",
            OldestFossilDate = dates.Any() ? dates.Min() : null,
            NewestFossilDate = dates.Any() ? dates.Max() : null,
            ServerTime = DateTime.Now
        };
    }
}

using Museum.Paleontology.Models;
using Museum.Paleontology.DTOs;

namespace Museum.Paleontology.Services;

public class FossilService : IFossilService
{
    public IEnumerable<Fossil> GetAllFossils(IEnumerable<Fossil> fossils)
    {
        return fossils;
    }

    public Fossil? GetFossilById(int id, IEnumerable<Fossil> fossils)
    {
        return fossils.FirstOrDefault(f => f.Id == id);
    }

    public IEnumerable<Fossil> FilterByEra(IEnumerable<Fossil> fossils, string era)
    {
        return fossils.Where(f =>
            f.Species?.Era.Equals(era, StringComparison.OrdinalIgnoreCase) == true);
    }

    public IEnumerable<Fossil> SortByDiscoveryDate(IEnumerable<Fossil> fossils, bool ascending = true)
    {
        return ascending
            ? fossils.OrderBy(f => f.DiscoveryDate)
            : fossils.OrderByDescending(f => f.DiscoveryDate);
    }

    public FossilStatisticsDto GetStatistics(IEnumerable<Fossil> fossils)
    {
        var fossilList = fossils.ToList();

        var years = fossilList
            .Where(f => f.DiscoveryDate.HasValue)
            .Select(f => f.DiscoveryDate!.Value.Year)
            .ToList();

        var eraGroups = fossilList
            .Where(f => f.Species?.Era != null)
            .GroupBy(f => f.Species!.Era)
            .OrderByDescending(g => g.Count())
            .ToList();

        return new FossilStatisticsDto
        {
            TotalCount = fossilList.Count,
            OldestFossilYear = years.Any() ? years.Min() : 0,
            NewestFossilYear = years.Any() ? years.Max() : 0,
            MostCommonEra = eraGroups.FirstOrDefault()?.Key ?? "Не определена",
            AverageAgeInYears = years.Any() ? Math.Round(years.Average(), 2) : 0
        };
    }
}
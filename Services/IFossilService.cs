using Museum.Paleontology.Models;
using Museum.Paleontology.DTOs;

namespace Museum.Paleontology.Services;

public interface IFossilService
{
    IEnumerable<Fossil> GetAllFossils(IEnumerable<Fossil> fossils);
    Fossil? GetFossilById(int id, IEnumerable<Fossil> fossils);
    IEnumerable<Fossil> FilterByEra(IEnumerable<Fossil> fossils, string era);
    IEnumerable<Fossil> SortByDiscoveryDate(IEnumerable<Fossil> fossils, bool ascending = true);
    FossilStatisticsDto GetStatistics(IEnumerable<Fossil> fossils);
}
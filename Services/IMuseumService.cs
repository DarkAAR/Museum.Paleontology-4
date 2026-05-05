using Museum.Paleontology.DTOs;
using Museum.Paleontology.Models;

namespace Museum.Paleontology.Services;

public interface IMuseumService
{
    MuseumInfoDto GetMuseumInfo(
        IEnumerable<Fossil> fossils,
        IEnumerable<Collection> collections,
        IEnumerable<Species> species,
        IEnumerable<Location> locations);
}
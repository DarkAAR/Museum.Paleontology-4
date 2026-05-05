namespace Museum.Paleontology.DTOs;
public class MuseumInfoDto
{
    public string MuseumName { get; set; } = string.Empty;
    public string Sphere { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int TotalFossils { get; set; }
    public int TotalCollections { get; set; }
    public int TotalSpecies { get; set; }
    public int TotalLocations { get; set; }
    public string MostCommonEra { get; set; } = string.Empty;
    public DateTime? OldestFossilDate { get; set; }
    public DateTime? NewestFossilDate { get; set; }
    public DateTime ServerTime { get; set; }
}


namespace Museum.Paleontology.DTOs;
public class FossilStatisticsDto
{
    public int TotalCount { get; set; }
    public int OldestFossilYear { get; set; }
    public int NewestFossilYear { get; set; }
    public string MostCommonEra { get; set; } = string.Empty;
    public double AverageAgeInYears { get; set; }
}
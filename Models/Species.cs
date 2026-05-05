using System.ComponentModel.DataAnnotations;

namespace Museum.Paleontology.Models;

public class Species
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string LatinName { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string CommonName { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Era { get; set; } = null!;

    public virtual ICollection<Fossil> Fossils { get; } = new List<Fossil>();
}
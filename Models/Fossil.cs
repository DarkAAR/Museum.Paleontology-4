using System.ComponentModel.DataAnnotations;

namespace Museum.Paleontology.Models;

public class Fossil
{
    public DateTime? DiscoveryDate { get; set; } 

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200, ErrorMessage = "Название не должно превышать 200 символов")]
    public string Name { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Required]
    public int CollectionId { get; set; }

    [Required]
    public int SpeciesId { get; set; }

    public int? LocationId { get; set; }

    public virtual Collection Collection { get; set; } = null!;
    public virtual Species Species { get; set; } = null!;
    public virtual Location? Location { get; set; }
}
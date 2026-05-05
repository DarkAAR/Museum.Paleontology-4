using System.ComponentModel.DataAnnotations;

namespace Museum.Paleontology.Models;

public class Collection
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(150, ErrorMessage = "Название не должно превышать 150 символов")]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    public virtual ICollection<Fossil> Fossils { get; } = new List<Fossil>();
}
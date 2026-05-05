using System.ComponentModel.DataAnnotations;

namespace Museum.Paleontology.Models;

public class Location
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string RoomNumber { get; set; } = null!;

    [StringLength(500)]
    public string? Notes { get; set; }
}
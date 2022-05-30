using System.ComponentModel.DataAnnotations;

namespace Hostels.Core.Entities;

public sealed class Building : IEntity
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Корпус")]
    public string? Title { get; set; }

    public ICollection<Category> Categories { get; set; } = new List<Category>();
}
using System.ComponentModel.DataAnnotations;
using Hostels.Core.Enums;

namespace Hostels.Core.Entities;

public sealed class HotelRoom : IEntity
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Номер")]
    public string? Title { get; set; }

    [Required]
    [Display(Name = "Статус")]
    public StatusEnum Status { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
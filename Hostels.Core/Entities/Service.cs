using System.ComponentModel.DataAnnotations;

namespace Hostels.Core.Entities;

public sealed class Service : IEntity
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Наименование")]
    public string? Title { get; set; }

    [Display(Name = "Описание")]
    public string? Description { get; set; }

    public int ServiceTypeId { get; set; }
    public ServiceType? ServiceType { get; set; }
}
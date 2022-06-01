using System.ComponentModel.DataAnnotations;

namespace Hostels.Core.Entities;

public sealed class ServiceType : IEntity
{
    public int Id { get; set; }

    [Display(Name = "Вид услуги")]
    public string? Title { get; set; }

    public ICollection<Service> Services { get; set; } = new List<Service>();
}
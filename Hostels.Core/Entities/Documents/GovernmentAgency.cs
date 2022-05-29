using System.ComponentModel.DataAnnotations;

namespace Hostels.Core.Entities.Documents;

public sealed class GovernmentAgency : IEntity
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите наименование государственного органа")]
    [Display(Name = "Государственный орган")]
    public string? Title { get; set; }

    public ICollection<Document> Documents { get; set; } = new List<Document>();
}
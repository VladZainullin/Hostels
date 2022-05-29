using System.ComponentModel.DataAnnotations;
using Hostels.Core.Entities.Documents;

namespace Hostels.Core.Entities;

public sealed class Document : IEntity
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Укажите серию документа")]
    [Display(Name = "Серия")]
    public int Series { get; set; }

    [Required(ErrorMessage = "Укажите номер документа")]
    [Display(Name = "Номер")]
    public int Number { get; set; }
    
    [Required(ErrorMessage = "Укажите дату выдачи")]
    [Display(Name = "Дата выдачи")]
    public DateTime DateOfIssue { get; set; }

    public int GovernmentAgencyId { get; set; }
    public GovernmentAgency? GovernmentAgency { get; set; }
}
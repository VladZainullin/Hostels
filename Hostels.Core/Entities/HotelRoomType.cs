using System.ComponentModel.DataAnnotations;

namespace Hostels.Core.Entities;

public sealed class HotelRoomType : IEntity
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите наименование типа гостиничного номера")]
    [Display(Name = "Тип гостиничного номера")]
    public string? Title { get; set; }
}
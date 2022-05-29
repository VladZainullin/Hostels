using System.ComponentModel.DataAnnotations;

namespace Hostels.Core.Entities;

public sealed class Category : IEntity
{
    public int Id { get; set; }

    [Display(Name = "Этаж")]
    public int Floor { get; set; }

    [Display(Name = "Вид из окна")]
    public string? ViewFromTheWindow { get; set; }

    [Display(Name = "Кол-во комнат")]
    public int NumberOfRooms { get; set; }

    [Display(Name = "Кол-во мест")]
    public int NumberOfSeats { get; set; }

    public int HotelRoomTypeId { get; set; }
    public HotelRoomType? HotelRoomType { get; set; }

    public int BuildingId { get; set; }
    public Building? Building { get; set; }
}
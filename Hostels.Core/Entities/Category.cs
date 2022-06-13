using System.ComponentModel.DataAnnotations;

namespace Hostels.Core.Entities;

public sealed class Category : IEntity
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Этаж")]
    public int Floor { get; set; }
    
    [Display(Name = "Вид из окна")]
    public string? ViewFromTheWindow { get; set; }

    [Required]
    [Display(Name = "Кол-во комнат")]
    public int NumberOfRooms { get; set; }

    [Required]
    [Display(Name = "Кол-во мест")]
    public int NumberOfSeats { get; set; }

    public int HotelRoomTypeId { get; set; }
    public HotelRoomType? HotelRoomType { get; set; }

    public int BuildingId { get; set; }
    public Building? Building { get; set; }

    public ICollection<HotelRoom> HotelRooms { get; set; } = new List<HotelRoom>();
    
    public ICollection<BookingRequest> BookingRequests { get; set; } = new List<BookingRequest>();
    
    public ICollection<PriceListRecord> PriceListRecords { get; set; } = new List<PriceListRecord>();
}
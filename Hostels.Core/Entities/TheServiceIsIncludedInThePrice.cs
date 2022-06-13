namespace Hostels.Core.Entities;

public sealed class TheServiceIsIncludedInThePrice : IEntity
{
    public int Id { get; set; }

    public int ServiceId { get; set; }
    public Service? Service { get; set; }

    public int HotelRoomId { get; set; }
    public HotelRoom? HotelRoom { get; set; }
}
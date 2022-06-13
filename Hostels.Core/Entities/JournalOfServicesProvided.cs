namespace Hostels.Core.Entities;

public sealed class JournalOfServicesProvided : IEntity
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public int BookingRequestId { get; set; }
    public BookingRequest? BookingRequest { get; set; }

    public int HotelRoomId { get; set; }
    public HotelRoom? HotelRoom { get; set; }

    public ICollection<TheServiceProvided> TheServiceProvideds { get; set; } = new List<TheServiceProvided>();
}
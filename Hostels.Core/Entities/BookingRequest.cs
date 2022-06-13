namespace Hostels.Core.Entities;

public sealed class BookingRequest : IEntity
{
    public int Id { get; set; }

    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

    public int CountOfClient { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
namespace Hostels.Core.Entities;

public sealed class Employee : IEntity
{
    public int Id { get; set; }

    public int PersonId { get; set; }
    public Person? Person { get; set; }

    public int PositionId { get; set; }
    public Position? Position { get; set; }
    
    public ICollection<BookingRequest> BookingRequests { get; set; } = new List<BookingRequest>();

    public ICollection<PriceList> PriceLists { get; set; } = new List<PriceList>();
}
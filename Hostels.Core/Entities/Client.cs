namespace Hostels.Core.Entities;

public sealed class Client : IEntity
{
    public int Id { get; set; }

    public int PersonId { get; set; }
    public Person? Person { get; set; }

    public int DocumentId { get; set; }
    public Document? Document { get; set; }

    public ICollection<BookingRequest> BookingRequests { get; set; } = new List<BookingRequest>();
}
namespace Hostels.Core.Entities;

public sealed class PriceListRecord : IEntity
{
    public int Id { get; set; }

    public int Cost { get; set; }

    public int ServiceId { get; set; }
    public Service? Service { get; set; }

    public int PriceListId { get; set; }
    public PriceList? PriceList { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
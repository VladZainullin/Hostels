namespace Hostels.Core.Entities;

public sealed class PriceListType : IEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }
    
    public ICollection<PriceList> PriceLists { get; set; } = new List<PriceList>();
}
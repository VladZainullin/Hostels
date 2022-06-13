namespace Hostels.Core.Entities;

public sealed class TheServiceProvided : IEntity
{
    public int Id { get; set; }

    public int Count { get; set; }

    public int PriceListRecordId { get; set; }
    public PriceListRecord? PriceListRecord { get; set; }

    public int JournalOfServicesProvidedId { get; set; }
    public JournalOfServicesProvided? JournalOfServicesProvided { get; set; }
}
namespace Hostels.Core.Entities;

public sealed class PriceList : IEntity
{
    public int Id { get; set; }

    public DateTime DateOfApplicationApproval { get; set; }

    public int PriceListTypeId { get; set; }
    public PriceListType? PriceListType { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    
    public ICollection<PriceListRecord> PriceListRecords { get; set; } = new List<PriceListRecord>();
}
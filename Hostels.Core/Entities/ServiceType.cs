namespace Hostels.Core.Entities;

public sealed class ServiceType : IEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
namespace Hostels.Core.Entities;

public sealed class Building : IEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
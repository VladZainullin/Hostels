namespace Hostels.Core.Entities;

public sealed class Position : IEntity
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
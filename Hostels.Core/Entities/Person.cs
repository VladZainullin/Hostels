using Hostels.Core.Enums;

namespace Hostels.Core.Entities;

public sealed class Person : IEntity
{
    public int Id { get; set; }

    public string? Patronymic { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }

    public GenderEnum GenderId { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public ICollection<Client> Clients { get; set; } = new List<Client>();

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
using Hostels.Core.Entities;
using Hostels.Core.Entities.Documents;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hostels.Data.Contexts;

public sealed class AppDbContext : IdentityDbContext
{
    public DbSet<Document> Documents { get; set; } = null!;
    
    public DbSet<GovernmentAgency> GovernmentAgencies { get; set; } = null!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
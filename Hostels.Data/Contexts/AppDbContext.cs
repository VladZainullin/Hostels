using Hostels.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hostels.Data.Contexts;

public sealed class AppDbContext : IdentityDbContext
{
    public DbSet<Document> Documents { get; set; } = null!;
    
    public DbSet<GovernmentAgency> GovernmentAgencies { get; set; } = null!;
    
    public DbSet<HotelRoomType> HostelRoomTypes { get; set; } = null!;
    
    public DbSet<Building> Buildings { get; set; } = null!;
    
    public DbSet<Category> –°ategories { get; set; } = null!;
    
    public DbSet<HotelRoom> HotelRooms { get; set; } = null!;
    
    public DbSet<Service> Services { get; set; } = null!;
    
    public DbSet<ServiceType> ServiceTypes { get; set; } = null!;
    
    public DbSet<Position> Positions { get; set; } = null!;
    
    public DbSet<PriceListType> PriceListTypes { get; set; } = null!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
using Hostels.Core.Entities;
using Hostels.Data.Contexts;
using Hostels.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Repositories

builder.Services.AddScoped<Repository<GovernmentAgency, AppDbContext>>();
builder.Services.AddScoped<Repository<Document, AppDbContext>>();

builder.Services.AddScoped<Repository<HotelRoomType, AppDbContext>>();
builder.Services.AddScoped<Repository<Building, AppDbContext>>();
builder.Services.AddScoped<Repository<Category, AppDbContext>>();
builder.Services.AddScoped<Repository<HotelRoom, AppDbContext>>();

builder.Services.AddScoped<Repository<Service, AppDbContext>>();
builder.Services.AddScoped<Repository<ServiceType, AppDbContext>>();

#endregion

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddDefaultIdentity<IdentityUser>(
        options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            options.User.RequireUniqueEmail = true;
        })
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
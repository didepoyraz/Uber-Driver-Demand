using DriverDemandApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DriverDemandApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    public DbSet<Ride> Rides => Set<Ride>();
}
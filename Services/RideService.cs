using DriverDemandApi.Data;
using DriverDemandApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DriverDemandApi.Services;

public class RideService
{
    private readonly AppDbContext _db;

    public RideService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Ride> CreateRideAsync(Ride ride)
    {
        _db.Rides.Add(ride);
        await _db.SaveChangesAsync();

        return ride;
    }

    public async Task<List<Ride>> GetRidesAsync()
    {
        return await _db.Rides.ToListAsync();
    }
}
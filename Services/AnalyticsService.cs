using DriverDemandApi.Data;
using DriverDemandApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DriverDemandApi.Services;

public class AnalyticsService
{
    private readonly AppDbContext _db;

    public AnalyticsService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<HotspotResponse>> GetHotspotsAsync(DayOfWeek day, int hour)
    {
        var result = await _db.Rides
            .Where(r => r.PickupTime.DayOfWeek == day && r.PickupTime.Hour == hour)
            .GroupBy(r => new { r.PickupArea, Hour = r.PickupTime.Hour })
            .Select(g => new HotspotResponse
            {
                PickupArea = g.Key.PickupArea,
                Hour = g.Key.Hour,
                RideCount = g.Count()
            })
            .OrderByDescending(x => x.RideCount)
            .ToListAsync();

        return result;
    }
}
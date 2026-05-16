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

    public async Task<List<HotspotResponse>> GetHotspotsAsync(DayOfWeek? day, int? hour)
    {
        var query = _db.Rides.AsQueryable();

        if (day.HasValue)
        {
            query = query.Where(r => r.PickupTime.DayOfWeek == day.Value);
        }

        if (hour.HasValue)
        {
            var selectedDay = day ?? DateTime.Now.DayOfWeek;

            query = query.Where(r =>
                r.PickupTime.DayOfWeek == selectedDay &&
                r.PickupTime.Hour == hour.Value);
        }

        var result = await query
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
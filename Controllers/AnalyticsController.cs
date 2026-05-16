using DriverDemandApi.DTOs;
using DriverDemandApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DriverDemandApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly AnalyticsService _analyticsService;

    public AnalyticsController(AnalyticsService analyticsService)
    {
        _analyticsService = analyticsService;
    }

    [HttpGet("hotspots")]
    public async Task<ActionResult<List<HotspotResponse>>> GetHotspots(
        [FromQuery] DayOfWeek? day,
        [FromQuery] int? hour)
    {
        var result = await _analyticsService.GetHotspotsAsync(day, hour);

        return Ok(result);
    }
}
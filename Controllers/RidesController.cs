using DriverDemandApi.Models;
using DriverDemandApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DriverDemandApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RidesController : ControllerBase
{
    private readonly RideService _rideService;

    public RidesController(RideService rideService)
    {
        _rideService = rideService;
    }

    [HttpPost]
    public async Task<ActionResult<Ride>> CreateRide(Ride ride)
    {
        var createdRide = await _rideService.CreateRideAsync(ride);
        return Ok(createdRide);
    }

    [HttpGet]
    public async Task<ActionResult<List<Ride>>> GetRides()
    {
        var rides = await _rideService.GetRidesAsync();
        return Ok(rides);
    }
}
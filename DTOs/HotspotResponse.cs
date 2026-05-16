namespace DriverDemandApi.DTOs;

public class HotspotResponse
{
    public string PickupArea { get; set; } = "";
    public int Hour { get; set; }
    public int RideCount {get; set; }

}
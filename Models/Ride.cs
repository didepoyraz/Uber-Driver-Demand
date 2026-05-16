namespace DriverDemandApi.Models;

public class Ride
{
    public int Id { get; set; }
    public string PickupArea { get; set; } = "";
    public DateTime PickupTime { get; set; }
    public decimal Fare { get; set; }
}
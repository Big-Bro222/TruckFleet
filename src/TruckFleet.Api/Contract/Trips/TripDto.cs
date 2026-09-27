namespace TruckFleet.Api.Contract.Trips;

public class TripDto
{
    public Guid Id { get; set; }
    public Guid TruckId { get; set; }
    public Guid DriverId { get; set; }
    public string Origin { get; set; } = "";
    public string Destination { get; set; } = "";
    public DateTimeOffset PlannedStartTime { get; set; }
    public DateTimeOffset PlannedEndTime { get; set; }
    public string Status { get; set; } = "";
}

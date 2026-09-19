using TruckFleet.Domain.Enums;

namespace TruckFleet.Domain.Entities;

public class Trip
{
    public Trip(Truck truck, Driver driver, string origin, string destination, DateTimeOffset plannedStartTime,
        DateTimeOffset plannedEndTime)
    {
        if (plannedStartTime >= plannedEndTime)
            throw new ArgumentException("PlannedEndTime must be after plannedStartTime");

        if (string.IsNullOrWhiteSpace(origin) || string.IsNullOrWhiteSpace(destination))
            throw new ArgumentException("Origin and Destination must not be empty");

        Truck = truck;
        Driver = driver;
        Origin = origin;
        Destination = destination;
        PlannedStartTime = plannedStartTime;
        PlannedEndTime = plannedEndTime;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public TripStatus Status { get; set; } = TripStatus.Draft;
    public string Origin { get; set; }
    public string Destination { get; set; }
    public Truck Truck { get; private set; }
    public Driver Driver { get; private set; }
    public DateTimeOffset PlannedStartTime { get; private set; }
    public DateTimeOffset PlannedEndTime { get; private set; }
    public DateTimeOffset? ActualStartTime { get; private set; }
    public DateTimeOffset? ActualEndTime { get; private set; }
}

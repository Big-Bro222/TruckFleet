namespace TruckFleet.Domain.Entities;

public class Fleet
{
    private readonly List<Truck> trucks = [];

    public Fleet(string fleetName)
    {
        Id = Guid.NewGuid();
        FleetName = fleetName;
    }

    public Guid Id { get; }
    public string FleetName { get; }

    public IReadOnlyCollection<Truck> Trucks => trucks;

    public void AddTruck(Truck truck)
    {
        if (trucks.Any(existingTruck => existingTruck.VIN == truck.VIN))
            throw new InvalidOperationException(
                $"VIN duplication, identical trucks are not allowed. VIN: {truck.VIN}");
        trucks.Add(truck);
    }
}

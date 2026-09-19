using TruckFleet.Domain.Enums;

namespace TruckFleet.Domain.Entities;

public class Truck
{
    public Truck(string vin, string name, string brand, TruckType truckType, TruckStatus status = TruckStatus.Unknown)
    {
        if (string.IsNullOrWhiteSpace(vin) || vin.Length != 17)
            throw new ArgumentException(
                "VIN must contain exactly 17 characters.",
                nameof(vin));

        VIN = vin;
        Name = name;
        Brand = brand;
        TruckType = truckType;
        Status = status;
    }

    public string VIN { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Brand { get; set; }
    public TruckType TruckType { get; set; }

    public TruckStatus Status { get; private set; }
    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
}

namespace TruckFleet.Api.Contract.Trucks;

public class TruckDto
{
    public Guid Id { get; set; }
    public string Vin { get; set; } = "";
    public string Name { get; set; } = "";
    public string Brand { get; set; } = "";
    public string TruckType { get; set; } = "";
    public string Status { get; set; } = "";
}


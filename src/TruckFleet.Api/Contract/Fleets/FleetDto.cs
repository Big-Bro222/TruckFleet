namespace TruckFleet.Api.Contract.Fleets;

public class FleetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public List<Guid> Trucks { get; set; } = [];
}

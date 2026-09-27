namespace TruckFleet.Api.Contract.Drivers;

public class DriverDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }  = "";
    public string LicenseNumber { get; set; } = "";
    public DateOnly LicenseExpiredDate { get; set; }
}

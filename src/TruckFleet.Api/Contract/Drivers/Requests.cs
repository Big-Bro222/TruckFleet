using System.ComponentModel.DataAnnotations;

namespace TruckFleet.Api.Contract.Drivers;

public class CreateDriverRequest
{
    [Required]
    public string Name { get; set; }  = "";
    [Required]
    public string LicenseNumber { get; set; } = "";
    [Required]
    public DateOnly LicenseExpiredDate { get; set; }
}

public class UpdateDriverRequest
{
    [Required]
    public string Name { get; set; }  = "";
    [Required]
    public DateOnly LicenseExpiredDate { get; set; }
}

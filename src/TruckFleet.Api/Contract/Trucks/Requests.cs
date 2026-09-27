using System.ComponentModel.DataAnnotations;

namespace TruckFleet.Api.Contract.Trucks;

public class CreateTruckRequest
{
    [Required]
    [StringLength(17, MinimumLength = 17)]
    public string Vin { get; set; } = "";
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public string Brand { get; set; } = "";
    [Required]
    public string TruckType { get; set; } = "";
}

public class UpdateTruckRequest
{
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public string Brand { get; set; } = "";
    [Required]
    public string TruckType { get; set; } = "";
}

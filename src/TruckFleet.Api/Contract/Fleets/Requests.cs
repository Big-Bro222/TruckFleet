using System.ComponentModel.DataAnnotations;

namespace TruckFleet.Api.Contract.Fleets;

public class CreateFleetRequest
{
    [Required]
    public string Name { get; set; } = "";
}

public class UpdateFleetRequest
{
    [Required]
    public string Name { get; set; } = "";
}

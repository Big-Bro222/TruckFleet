using System.ComponentModel.DataAnnotations;

namespace TruckFleet.Api.Contract.Trips;

public class CreateTripRequest
{
    [Required]
    public Guid TruckId { get; set; }

    [Required]
    public Guid DriverId { get; set; }

    [Required]
    public string Origin { get; set; } = "";

    [Required]
    public string Destination { get; set; } = "";

    [Required]
    public DateTimeOffset PlannedStartTime { get; set; }

    [Required]
    public DateTimeOffset PlannedEndTime { get; set; }
}

public class UpdateTripRequest
{
    [Required]
    public Guid TruckId { get; set; }

    [Required]
    public Guid DriverId { get; set; }

    [Required]
    public string Origin { get; set; } = "";

    [Required]
    public string Destination { get; set; } = "";

    [Required]
    public DateTimeOffset PlannedStartTime { get; set; }

    [Required]
    public DateTimeOffset PlannedEndTime { get; set; }
}

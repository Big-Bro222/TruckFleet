using Microsoft.AspNetCore.Mvc;
using TruckFleet.Api.Contract.Trips;
using TruckFleet.Api.Services;

namespace TruckFleet.Api.Controllers;

[ApiController]
[Route("api/trips")]
public class TripController : ControllerBase
{
    private readonly ITripStorage tripStorage;
    private readonly ITruckStorage truckStorage;
    private readonly IDriverStorage driverStorage;

    public TripController(
        ITripStorage tripStorage,
        ITruckStorage truckStorage,
        IDriverStorage driverStorage)
    {
        this.tripStorage = tripStorage;
        this.truckStorage = truckStorage;
        this.driverStorage = driverStorage;
    }

    #region Get

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<TripDto>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyCollection<TripDto>> GetTrips(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IReadOnlyCollection<TripDto> trips = tripStorage.GetAllTrips();

        return Ok(trips);
    }

    [HttpGet("{tripId:guid}")]
    [ProducesResponseType(typeof(TripDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TripDto> GetTrip(Guid tripId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        TripDto? trip = tripStorage.GetTrip(tripId);
        if (trip == null)
        {
            return NotFound();
        }

        return Ok(trip);
    }

    #endregion

    #region Post

    [HttpPost]
    [ProducesResponseType(typeof(TripDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TripDto> CreateTrip(CreateTripRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ActionResult? validationResult = ValidateTripRequest(
            request.TruckId,
            request.DriverId,
            request.PlannedStartTime,
            request.PlannedEndTime);

        if (validationResult != null)
        {
            return validationResult;
        }

        TripDto trip = new()
        {
            Id = Guid.NewGuid(),
            TruckId = request.TruckId,
            DriverId = request.DriverId,
            Origin = request.Origin,
            Destination = request.Destination,
            PlannedStartTime = request.PlannedStartTime,
            PlannedEndTime = request.PlannedEndTime,
            Status = "Draft"
        };

        tripStorage.AddTrip(trip);

        return Created($"/api/trips/{trip.Id}", trip);
    }

    #endregion

    #region Put

    [HttpPut("{tripId:guid}")]
    [ProducesResponseType(typeof(TripDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TripDto> UpdateTrip(
        Guid tripId,
        UpdateTripRequest request,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ActionResult? validationResult = ValidateTripRequest(
            request.TruckId,
            request.DriverId,
            request.PlannedStartTime,
            request.PlannedEndTime);

        if (validationResult != null)
        {
            return validationResult;
        }

        TripDto? trip = tripStorage.TryUpdateTrip(request, tripId);
        if (trip == null)
        {
            return NotFound();
        }

        return Ok(trip);
    }

    #endregion

    #region Delete

    [HttpDelete("{tripId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteTrip(Guid tripId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (tripStorage.TryRemoveTrip(tripId))
        {
            return NoContent();
        }

        return NotFound();
    }

    #endregion

    private ActionResult? ValidateTripRequest(
        Guid truckId,
        Guid driverId,
        DateTimeOffset plannedStartTime,
        DateTimeOffset plannedEndTime)
    {
        if (plannedStartTime >= plannedEndTime)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Invalid planned time range.",
                Detail = "Planned end time must be after planned start time.",
                Status = StatusCodes.Status400BadRequest
            });
        }

        if (truckStorage.GetTruck(truckId) == null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Truck not found.",
                Detail = "The requested truck does not exist.",
                Status = StatusCodes.Status404NotFound
            });
        }

        if (driverStorage.GetDriver(driverId) == null)
        {
            return NotFound(new ProblemDetails
            {
                Title = "Driver not found.",
                Detail = "The requested driver does not exist.",
                Status = StatusCodes.Status404NotFound
            });
        }

        return null;
    }
}

using Microsoft.AspNetCore.Mvc;
using TruckFleet.Api.Contract.Trucks;
using TruckFleet.Api.Services;

namespace TruckFleet.Api.Controllers;

[ApiController]
[Route("api/trucks")]
public class TruckController : ControllerBase
{

    private readonly ITruckStorage truckStorage;

    public TruckController(ITruckStorage truckStorage)
    {
        this.truckStorage = truckStorage;
    }

    #region Get

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<TruckDto>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyCollection<TruckDto>> GetTrucks(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IReadOnlyCollection<TruckDto> trucks = truckStorage.GetAllTrucks();

        return Ok(trucks);
    }

    [HttpGet("{truckId:guid}")]
    [ProducesResponseType(typeof(TruckDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TruckDto> GetTruck(Guid truckId, CancellationToken cancellationToken)
    {

        cancellationToken.ThrowIfCancellationRequested();
        TruckDto? truck = truckStorage.GetTruck(truckId);
        if (truck == null)
        {

            return NotFound();
        }

        return Ok(truck);
    }

    #endregion

    #region Post

    [HttpPost]
    [ProducesResponseType(typeof(TruckDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<TruckDto> CreateTruck(CreateTruckRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (truckStorage.Exists(request.Vin))
        {
            return Conflict();
        }

        TruckDto truck = new()
        {
            Id = Guid.NewGuid(),
            Vin = request.Vin,
            Name = request.Name,
            Brand = request.Brand,
            TruckType = request.TruckType,
            Status = "Unknown"
        };

        truckStorage.AddTruck(truck);
        return Created($"/api/trucks/{truck.Id}", truck);
    }

    #endregion

    #region Put

    [HttpPut("{truckId:guid}")]
    [ProducesResponseType(typeof(TruckDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<TruckDto> UpdateTruck(Guid truckId, UpdateTruckRequest request,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        TruckDto? truck = truckStorage.TryUpdateTruck(request, truckId);
        if (truck == null)
        {
            return NotFound();
        }

        ;
        return Ok(truck);
    }

    #endregion

    #region Delete

    [HttpDelete("{truckId:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult DeleteTruck(Guid truckId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (truckStorage.TryRemoveTruck(truckId))
        {
            return NoContent();
        }

        return NotFound();
    }

    #endregion

}

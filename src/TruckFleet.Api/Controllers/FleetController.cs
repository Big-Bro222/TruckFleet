using Microsoft.AspNetCore.Mvc;
using TruckFleet.Api.Contract.Fleets;
using TruckFleet.Api.Services;

namespace TruckFleet.Api.Controllers;

[ApiController]
[Route("api/fleets")]
public class FleetController : ControllerBase
{

    private readonly IFleetStorage fleetStorage;

    public FleetController(IFleetStorage fleetStorage)
    {
        this.fleetStorage = fleetStorage;
    }

    #region Get

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<FleetDto>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyCollection<FleetDto>> GetFleets(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IReadOnlyCollection<FleetDto> fleets = fleetStorage.GetAllFleets();

        return Ok(fleets);
    }

    [HttpGet("{fleetId:guid}")]
    [ProducesResponseType(typeof(FleetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<FleetDto> GetFleet(Guid fleetId, CancellationToken cancellationToken)
    {

        cancellationToken.ThrowIfCancellationRequested();
        FleetDto? fleet = fleetStorage.GetFleet(fleetId);
        if (fleet == null)
        {

            return NotFound();
        }

        return Ok(fleet);
    }

    #endregion

    #region Post

    [HttpPost]
    [ProducesResponseType(typeof(FleetDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<FleetDto> CreateFleet(CreateFleetRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (fleetStorage.Exists(request.Name))
        {
            return Conflict();
        }

        FleetDto fleet = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        };

        fleetStorage.AddFleet(fleet);
        return Created($"/api/fleets/{fleet.Id}", fleet);
    }



    #endregion

    #region Put

    [HttpPut("{fleetId:guid}")]
    [ProducesResponseType(typeof(FleetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<FleetDto> UpdateFleetInfo(Guid fleetId, UpdateFleetRequest request,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        FleetDto? fleet = fleetStorage.TryUpdateFleet(request, fleetId);
        if (fleet == null)
        {
            return NotFound();
        }

        return Ok(fleet);
    }

    #endregion

    #region Delete

    [HttpDelete("{fleetId:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult DeleteFleet(Guid fleetId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (fleetStorage.TryRemoveFleet(fleetId))
        {
            return NoContent();
        }

        return NotFound();
    }

    #endregion

}


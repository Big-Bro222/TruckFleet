using Microsoft.AspNetCore.Mvc;
using TruckFleet.Api.Contract.Drivers;
using TruckFleet.Api.Services;

namespace TruckFleet.Api.Controllers;

[ApiController]
[Route("api/drivers")]
public class DriverController : ControllerBase
{

    private readonly IDriverStorage driverStorage;

    public DriverController(IDriverStorage driverStorage)
    {
        this.driverStorage = driverStorage;
    }

    #region Get

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<DriverDto>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyCollection<DriverDto>> GetDrivers(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IReadOnlyCollection<DriverDto> drivers = driverStorage.GetAllDrivers();

        return Ok(drivers);
    }

    [HttpGet("{driverId:guid}")]
    [ProducesResponseType(typeof(DriverDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DriverDto> GetDriver(Guid driverId, CancellationToken cancellationToken)
    {

        cancellationToken.ThrowIfCancellationRequested();
        DriverDto? driver = driverStorage.GetDriver(driverId);
        if (driver == null)
        {

            return NotFound();
        }

        return Ok(driver);
    }

    #endregion

    #region Post

    [HttpPost]
    [ProducesResponseType(typeof(DriverDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<DriverDto> CreateDriver(CreateDriverRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (driverStorage.Exists(request.LicenseNumber))
        {
            return Conflict();
        }

        DriverDto driver = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            LicenseNumber = request.LicenseNumber,
            LicenseExpiredDate = request.LicenseExpiredDate,
        };

        driverStorage.AddDriver(driver);
        return Created($"/api/drivers/{driver.Id}", driver);
    }

    #endregion

    #region Put

    [HttpPut("{driverId:guid}")]
    [ProducesResponseType(typeof(DriverDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<DriverDto> UpdateDriver(Guid driverId, UpdateDriverRequest request,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        DriverDto? driver = driverStorage.TryUpdateDriver(request, driverId);
        if (driver == null)
        {
            return NotFound();
        }

        ;
        return Ok(driver);
    }

    #endregion

    #region Delete

    [HttpDelete("{driverId:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult DeleteDriver(Guid driverId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (driverStorage.TryRemoveDriver(driverId))
        {
            return NoContent();
        }

        return NotFound();
    }

    #endregion

}


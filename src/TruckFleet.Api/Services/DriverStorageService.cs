using TruckFleet.Api.Contract.Drivers;

namespace TruckFleet.Api.Services;

public interface IDriverStorage
{
    public IReadOnlyCollection<DriverDto> GetAllDrivers();
    public void AddDriver(DriverDto driver);
    public DriverDto? GetDriver(Guid guid);
    public bool TryRemoveDriver(Guid guid);

    public DriverDto? TryUpdateDriver(UpdateDriverRequest driver, Guid guid);

    public bool Exists(string licenseNumber);
}

public class DriverStorageService : IDriverStorage
{
    private readonly Dictionary<Guid, DriverDto> drivers = new();

    public void AddDriver(DriverDto driver)
    {
        drivers.Add(driver.Id, driver);
    }

    public bool TryRemoveDriver(Guid guid)
    {
        return drivers.Remove(guid);
    }

    public DriverDto? TryUpdateDriver(UpdateDriverRequest driverRequest, Guid guid)
    {
        if (!drivers.TryGetValue(guid, out DriverDto? driverToUpdate))
        {
            return null;
        }
        driverToUpdate.LicenseExpiredDate = driverRequest.LicenseExpiredDate;
        driverToUpdate.Name = driverRequest.Name;
        return driverToUpdate;
    }

    public bool Exists(string licenseNumber)
    {
        return drivers.Values.Any(driver => driver.LicenseNumber == licenseNumber);
    }

    public DriverDto? GetDriver(Guid guid)
    {
        return drivers.GetValueOrDefault(guid);
    }

    public IReadOnlyCollection<DriverDto> GetAllDrivers()
    {
        return drivers.Values.ToArray();
    }
}

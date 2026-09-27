using TruckFleet.Api.Contract.Fleets;

namespace TruckFleet.Api.Services;

public interface IFleetStorage
{
    public IReadOnlyCollection<FleetDto> GetAllFleets();
    public void AddFleet(FleetDto fleet);
    public FleetDto? GetFleet(Guid guid);
    public bool TryRemoveFleet(Guid guid);

    public FleetDto? TryUpdateFleet(UpdateFleetRequest fleet, Guid guid);

    public bool Exists(string name);
}

public class FleetStorageService : IFleetStorage
{
    private readonly Dictionary<Guid, FleetDto> fleets = new();

    #region FleetOperation

    public void AddFleet(FleetDto fleet)
    {
        fleets.Add(fleet.Id, fleet);
    }

    public bool TryRemoveFleet(Guid guid)
    {
        return fleets.Remove(guid);
    }

    public FleetDto? TryUpdateFleet(UpdateFleetRequest fleetRequest, Guid guid)
    {
        if (!fleets.TryGetValue(guid, out FleetDto? fleetToUpdate))
        {
            return null;
        }
        fleetToUpdate.Name = fleetRequest.Name;
        return fleetToUpdate;
    }

    public bool Exists(string name)
    {
        return fleets.Values.Any(fleet => fleet.Name == name);
    }

    public FleetDto? GetFleet(Guid guid)
    {
        return fleets.GetValueOrDefault(guid);
    }

    public IReadOnlyCollection<FleetDto> GetAllFleets()
    {
        return fleets.Values.ToArray();
    }

    #endregion

}

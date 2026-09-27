using TruckFleet.Api.Contract.Trucks;

namespace TruckFleet.Api.Services;

public interface ITruckStorage
{
    public IReadOnlyCollection<TruckDto> GetAllTrucks();
    public void AddTruck(TruckDto truck);
    public TruckDto? GetTruck(Guid guid);
    public bool Exists(string vin);
    public bool TryRemoveTruck(Guid guid);

    public TruckDto? TryUpdateTruck(UpdateTruckRequest truck, Guid guid);
}

public class TruckStorageService : ITruckStorage
{
    private readonly Dictionary<Guid, TruckDto> trucks = new();

    public void AddTruck(TruckDto truck)
    {
        trucks.Add(truck.Id, truck);
    }

    public bool Exists(string vin)
    {
        return trucks.Values.Any(truck => truck.Vin == vin);
    }

    public bool TryRemoveTruck(Guid guid)
    {
        return trucks.Remove(guid);
    }

    public TruckDto? TryUpdateTruck(UpdateTruckRequest truckRequest, Guid guid)
    {
        if (!trucks.TryGetValue(guid, out TruckDto? truckToUpdate))
        {
            return null;
        }
        truckToUpdate.Brand = truckRequest.Brand;
        truckToUpdate.Name = truckRequest.Name;
        truckToUpdate.TruckType = truckRequest.TruckType;
        return truckToUpdate;
    }

    public TruckDto? GetTruck(Guid guid)
    {
        return trucks.GetValueOrDefault(guid);
    }

    public IReadOnlyCollection<TruckDto> GetAllTrucks()
    {
        return trucks.Values.ToArray();
    }
}

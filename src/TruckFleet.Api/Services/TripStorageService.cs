using TruckFleet.Api.Contract.Trips;

namespace TruckFleet.Api.Services;

public interface ITripStorage
{
    public IReadOnlyCollection<TripDto> GetAllTrips();
    public void AddTrip(TripDto trip);
    public TripDto? GetTrip(Guid guid);
    public bool TryRemoveTrip(Guid guid);
    public TripDto? TryUpdateTrip(UpdateTripRequest trip, Guid guid);
}

public class TripStorageService : ITripStorage
{
    private readonly Dictionary<Guid, TripDto> trips = new();

    public IReadOnlyCollection<TripDto> GetAllTrips()
    {
        return trips.Values.ToArray();
    }

    public void AddTrip(TripDto trip)
    {
        trips.Add(trip.Id, trip);
    }

    public TripDto? GetTrip(Guid guid)
    {
        return trips.GetValueOrDefault(guid);
    }

    public bool TryRemoveTrip(Guid guid)
    {
        return trips.Remove(guid);
    }

    public TripDto? TryUpdateTrip(UpdateTripRequest tripRequest, Guid guid)
    {
        if (!trips.TryGetValue(guid, out TripDto? tripToUpdate))
        {
            return null;
        }

        tripToUpdate.TruckId = tripRequest.TruckId;
        tripToUpdate.DriverId = tripRequest.DriverId;
        tripToUpdate.Origin = tripRequest.Origin;
        tripToUpdate.Destination = tripRequest.Destination;
        tripToUpdate.PlannedStartTime = tripRequest.PlannedStartTime;
        tripToUpdate.PlannedEndTime = tripRequest.PlannedEndTime;

        return tripToUpdate;
    }
}

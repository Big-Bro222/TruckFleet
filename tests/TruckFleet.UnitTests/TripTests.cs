using TruckFleet.Domain.Entities;
using TruckFleet.Domain.Enums;

namespace TruckFleet.UnitTests;

public class TripTests
{
    [Fact]
    public void NewTrip_WithValidData_ShouldStoreValuesAndHaveDraftStatus()
    {
        // Arrange
        Truck truck = new("12345678901234567", "Truck 01", "Volvo", TruckType.Tractor);
        Driver driver = new("Alex Johnson", "DL-123456", new DateOnly(2030, 12, 31));
        string origin = "Stockholm";
        string destination = "Gothenburg";
        DateTimeOffset plannedStartTime = new(2026, 9, 18, 8, 0, 0, TimeSpan.Zero);
        DateTimeOffset plannedEndTime = new(2026, 9, 18, 16, 0, 0, TimeSpan.Zero);

        // Act
        Trip trip = new(truck, driver, origin, destination, plannedStartTime, plannedEndTime);

        // Assert
        // write assertions here
        Assert.Equal(TripStatus.Draft, trip.Status);
        Assert.NotEqual(trip.Id, Guid.Empty);
        Assert.Equal(truck.Id, trip.Truck.Id);
        Assert.Equal(driver.Id, trip.Driver.Id);
        Assert.Equal(origin, trip.Origin);
        Assert.Equal(destination, trip.Destination);
        Assert.Equal(plannedStartTime, trip.PlannedStartTime);
        Assert.Equal(plannedEndTime, trip.PlannedEndTime);
        Assert.Null(trip.ActualStartTime);
        Assert.Null(trip.ActualEndTime);
    }

    [Fact]
    public void NewTrip_WithPlannedEndBeforeStart_ShouldThrowArgumentException()
    {
        // Arrange
        Truck truck = new("12345678901234567", "Truck 01", "Volvo", TruckType.Tractor);
        Driver driver = new("Alex Johnson", "DL-123456", new DateOnly(2030, 12, 31));
        string origin = "Stockholm";
        string destination = "Gothenburg";
        DateTimeOffset plannedStartTime = new(2026, 9, 18, 8, 0, 0, TimeSpan.Zero);
        DateTimeOffset plannedEndTime = new(2026, 9, 17, 16, 0, 0, TimeSpan.Zero);

        Action addTrip = () => new Trip(truck, driver, origin, destination, plannedStartTime, plannedEndTime);
        Assert.Throws<ArgumentException>(addTrip);
    }

    [Fact]
    public void NewTrip_WithEmptyOrigin_ShouldThrowArgumentException()
    {
        Truck truck = new("12345678901234567", "Truck 01", "Volvo", TruckType.Tractor);
        Driver driver = new("Alex Johnson", "DL-123456", new DateOnly(2030, 12, 31));
        string origin = "";
        string destination = "Gothenburg";
        DateTimeOffset plannedStartTime = new(2026, 9, 18, 8, 0, 0, TimeSpan.Zero);
        DateTimeOffset plannedEndTime = new(2026, 9, 18, 16, 0, 0, TimeSpan.Zero);

        Action addTrip = () => new Trip(truck, driver, origin, destination, plannedStartTime, plannedEndTime);
        Assert.Throws<ArgumentException>(addTrip);
    }

    [Fact]
    public void NewTrip_WithEmptyDestination_ShouldThrowArgumentException()
    {
        Truck truck = new("12345678901234567", "Truck 01", "Volvo", TruckType.Tractor);
        Driver driver = new("Alex Johnson", "DL-123456", new DateOnly(2030, 12, 31));
        string origin = "Stockholm";
        string destination = "";
        DateTimeOffset plannedStartTime = new(2026, 9, 18, 8, 0, 0, TimeSpan.Zero);
        DateTimeOffset plannedEndTime = new(2026, 9, 18, 16, 0, 0, TimeSpan.Zero);

        Action addTrip = () => new Trip(truck, driver, origin, destination, plannedStartTime, plannedEndTime);
        Assert.Throws<ArgumentException>(addTrip);
    }
}

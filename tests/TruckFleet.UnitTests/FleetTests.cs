using TruckFleet.Domain.Entities;
using TruckFleet.Domain.Enums;

namespace TruckFleet.UnitTests;

public class FleetTests
{
    [Fact]
    public void NewFleet_ShouldHaveGeneratedIdAndNoTrucks()
    {
        Fleet fleet = new("Fleet 1");
        Assert.NotEqual(Guid.Empty, fleet.Id);
        Assert.Equal("Fleet 1", fleet.FleetName);
        Assert.Empty(fleet.Trucks);
    }

    [Fact]
    public void AddTruck_ShouldAddTruckToFleet()
    {
        Fleet fleet = new("Fleet 1");
        Truck truck = new(
            "11111111111111111",
            "Truck 01",
            "Scania",
            TruckType.Tractor);

        fleet.AddTruck(truck);

        Assert.Single(fleet.Trucks);
        Assert.Contains(truck, fleet.Trucks);
    }

    [Fact]
    public void AddTruck_WithDuplicateVin_ShouldThrowInvalidOperationException()
    {
        // Arrange
        Fleet fleet = new("Fleet 1");

        Truck firstTruck = new(
            "11111111111111111",
            "Truck 01",
            "Scania",
            TruckType.Tractor);

        Truck duplicateTruck = new(
            "11111111111111111",
            "Truck 02",
            "Volvo",
            TruckType.RigidTruck);

        fleet.AddTruck(firstTruck);

        // Act
        Action addDuplicateTruck = () => fleet.AddTruck(duplicateTruck);

        // Assert
        Assert.Throws<InvalidOperationException>(addDuplicateTruck);
        Assert.Single(fleet.Trucks);
    }
}

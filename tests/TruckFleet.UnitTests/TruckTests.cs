using TruckFleet.Domain.Entities;
using TruckFleet.Domain.Enums;

namespace TruckFleet.UnitTests;

public class TruckTests
{
    [Fact]
    public void NewTruck_ShouldHaveUnknownStatus()
    {
        // Arrange
        const string VIN = "12345678901234567";

        // Act
        Truck truck = new(VIN, "Truck 01", "Scania", TruckType.Tractor);

        // Assert
        Assert.Equal(TruckStatus.Unknown, truck.Status);
    }

    [Theory]
    [InlineData("")]
    [InlineData("1234567890123456")]
    [InlineData("123456789012345678")]
    public void NewTruck_WithInvalidVin_ShouldThrowArgumentException(string vin)
    {
        Action createTruck = () => _ = new Truck
            (vin, "Truck 01", "Scania", TruckType.Tractor);

        Assert.Throws<ArgumentException>(createTruck);
    }

    [Fact]
    public void NewTruck_WithValidData_ShouldStoreProvidedValues()
    {
        // Arrange
        const string VIN = "11111111111111111";

        // Act
        Truck truck = new(VIN, "Truck 01", "Scania", TruckType.Tractor);

        Assert.Equal(VIN, truck.VIN);
        Assert.Equal("Truck 01", truck.Name);
        Assert.Equal("Scania", truck.Brand);
        Assert.Equal(TruckType.Tractor, truck.TruckType);
        Assert.Equal(TruckStatus.Unknown, truck.Status);
        Assert.NotEqual(Guid.Empty, truck.Id);
        Assert.NotEqual(default, truck.CreatedAt);
    }
}

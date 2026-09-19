using TruckFleet.Domain.Entities;

namespace TruckFleet.UnitTests;

public class DriverTests
{
    [Fact]
    public void NewDriver_WithValidData_ShouldStoreProvidedValues()
    {
        // Arrange
        const string name = "Alex Johnson";
        const string licenseNumber = "DL-123456";
        DateOnly expiryDate = new(2030, 12, 31);

        // Act
        Driver driver = new(name, licenseNumber, expiryDate);

        // Assert
        Assert.NotEqual(Guid.Empty, driver.Id);
        Assert.Equal(name, driver.Name);
        Assert.Equal(licenseNumber, driver.LicenseNumber);
        Assert.Equal(expiryDate, driver.LicenseExpiredDate);
    }

    [Theory]
    [InlineData("")]
    public void NewDriver_WithInvalidData_ShouldThrowException(string name)
    {
        // Arrange
        const string licenseNumber = "DL-123456";
        DateOnly expiryDate = new(2030, 12, 31);

        // Act
        Action addNewDriver = () => new Driver(name, licenseNumber, expiryDate);

        // Assert
        Assert.Throws<ArgumentException>(addNewDriver);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void NewDriver_WithInvalidLicenseNumber_ShouldThrowException(string licenseNumber)
    {
        // Arrange
        const string name = "Alex Johnson";
        DateOnly expiryDate = new(2030, 12, 31);

        // Act
        Action addNewDriver = () => new Driver(name, licenseNumber, expiryDate);

        // Assert
        Assert.Throws<ArgumentException>(addNewDriver);
    }
}

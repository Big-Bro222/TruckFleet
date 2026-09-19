namespace TruckFleet.Domain.Entities;

public class Driver
{
    public Driver(string name, string licenseNumber, DateOnly licenseExpiredDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Driver name cannot be null or whitespace.", nameof(name));

        if (string.IsNullOrWhiteSpace(licenseNumber))
            throw new ArgumentException(
                "Driver License Invalid.", nameof(name));
        Name = name;
        LicenseNumber = licenseNumber;
        LicenseExpiredDate = licenseExpiredDate;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string LicenseNumber { get; set; }
    public DateOnly LicenseExpiredDate { get; }
}

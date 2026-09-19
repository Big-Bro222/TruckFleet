using TruckFleet.Domain.Entities;

namespace TruckFleet.UnitTests;

public class OrganizationTests
{
    [Fact]
    public void NewOrganization_ShouldHaveGeneratedIdAndNoFleets()
    {
        // Act
        Organization organization = new("Nordic Transport");

        // Assert
        Assert.NotEqual(Guid.Empty, organization.Id);
        Assert.Equal("Nordic Transport", organization.Name);
        Assert.Empty(organization.Fleets);
    }
}

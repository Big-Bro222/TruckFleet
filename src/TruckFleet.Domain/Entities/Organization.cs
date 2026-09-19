namespace TruckFleet.Domain.Entities;

public class Organization
{
    private readonly List<Fleet> fleets = [];

    public Organization(string organizationName)
    {
        Id = Guid.NewGuid();
        Name = organizationName;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public IReadOnlyCollection<Fleet> Fleets => fleets;

    public void AddFleet(Fleet fleet)
    {
        fleets.Add(fleet);
    }
}

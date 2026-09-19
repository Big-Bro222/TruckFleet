# TruckFleet ERD

This first ERD describes the Week 1 domain model. It is intentionally small and focuses on the core business concepts before APIs, persistence, telemetry, and authentication are added.

```mermaid
erDiagram
    ORGANIZATION ||--o{ FLEET : owns
    FLEET ||--o{ TRUCK : contains
    TRUCK ||--o{ TRIP : assigned_to
    DRIVER ||--o{ TRIP : drives

    ORGANIZATION {
        Guid Id
        string Name
    }

    FLEET {
        Guid Id
        string FleetName
    }

    TRUCK {
        Guid Id
        string VIN
        string Name
        string Brand
        TruckType TruckType
        TruckStatus Status
        DateTimeOffset CreatedAt
    }

    DRIVER {
        Guid Id
        string Name
        string LicenseNumber
        DateOnly LicenseExpiryDate
    }

    TRIP {
        Guid Id
        string Origin
        string Destination
        DateTimeOffset PlannedStartTime
        DateTimeOffset PlannedEndTime
        DateTimeOffset ActualStartTime
        DateTimeOffset ActualEndTime
        TripStatus Status
    }
```

## Notes

- This diagram shows domain relationships, not final database tables.

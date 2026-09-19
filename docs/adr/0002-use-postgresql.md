# 0002 Use PostgreSQL

## Status

Accepted

## Implementation Status

Planned

## Context

TruckFleet will eventually need persistent storage for organizations, fleets, trucks, drivers, trips, users, roles, telemetry records, alerts, and service-planning data.

The project does not use a database in Week 1. Persistence will be introduced later after the initial domain model and API boundaries are clearer.

## Decision

TruckFleet will use PostgreSQL when persistence is introduced.

PostgreSQL is selected because it is a widely used relational database with strong support for structured business data, constraints, indexing, transactions, and cloud deployment.

## Consequences

Using PostgreSQL gives the project a realistic production-style database choice for a backend portfolio project.

It fits well with Entity Framework Core and integration testing with containers.

The project will avoid database-specific complexity until the persistence week. In Week 1, the decision only records the intended direction.

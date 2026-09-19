# 0001 Use Modular Monolith

## Status

Accepted

## Implementation Status

Started

## Context

TruckFleet is a learning and portfolio backend project built by one developer.

The project needs clear separation between API, application logic, domain rules, and infrastructure code. At the current stage, it does not need independent service deployment, distributed communication, or separate scaling per feature.

## Decision

TruckFleet will start as a modular monolith.

The solution is split into separate projects:

- `TruckFleet.Api`
- `TruckFleet.Application`
- `TruckFleet.Domain`
- `TruckFleet.Infrastructure`

The goal is to keep the system simple while still practicing clean architectural boundaries.

## Consequences

This approach keeps local development, testing, and deployment easier during the MVP stage.

It also allows the project to grow in a structured way without introducing microservice complexity too early.

Microservices are deferred until there is a real need for independent deployment, scaling, or team ownership.

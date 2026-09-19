# TruckFleet

TruckFleet is a .NET backend portfolio project for commercial fleet management.

The project models core fleet operations such as organizations, fleets, trucks, drivers, and trips. It is built incrementally as a learning project, starting with a clean domain model and later expanding into APIs, persistence, authentication, telemetry, real-time updates, and cloud deployment.

## Target Users

TruckFleet is designed around users who manage commercial transport operations, such as:

- Fleet managers who need to track trucks, drivers, and trips
- Transport coordinators who plan vehicle usage
- Operations teams who need reliable vehicle status information
- Backend engineers reviewing a realistic domain-driven portfolio project

## Problem

Commercial fleet operations involve multiple connected concepts:

- An organization may operate multiple fleets
- A fleet contains multiple trucks
- Trucks have operational states such as available, in operation, maintenance, or retired
- Drivers have licenses and can be assigned to transport work
- Trips connect trucks, drivers, origins, destinations, and planned time windows

The goal of TruckFleet is to model these concepts clearly and grow them into a realistic backend system over time.

## MVP Scope

The MVP focuses on a backend system for managing fleet operations.

The planned MVP includes:

- Organization and fleet management
- Truck management
- Driver management
- Trip planning and lifecycle tracking
- REST APIs
- PostgreSQL persistence with Entity Framework Core
- Authentication and role-based authorization
- Simulated vehicle telemetry
- rFMS-aligned vehicle data concepts
- Real-time fleet position updates with SignalR
- Automated tests
- Docker-based local development
- Cloud deployment as a portfolio demo

## Week 1 Scope

Week 1 focuses on project structure and domain modelling.

Implemented or planned for Week 1:

- .NET solution structure
- API, Application, Domain, Infrastructure, Unit Test, and Integration Test projects
- Core domain entities:
    - Organization
    - Fleet
    - Truck
    - Driver
    - Trip
- Basic domain rules:
    - Trucks require a valid VIN length
    - Fleets reject duplicate truck VINs
    - Drivers require a name and license number
    - Trips require valid planned time ranges
    - Trips start in draft status
- Unit tests for the initial domain model

## Technology Stack

Planned stack:

- .NET 10
- ASP.NET Core Web API
- C#
- xUnit
- PostgreSQL
- Entity Framework Core
- JWT authentication
- Role-based access control
- SignalR
- Docker
- GitHub Actions
- Azure

Not all technologies are implemented in Week 1. The project is intentionally built step by step.

## Disclaimer

TruckFleet is an independent portfolio project inspired by publicly documented commercial fleet-management concepts and rFMS terminology.


It is not affiliated with, endorsed by, or connected to Scania. Any references to commercial vehicle concepts are used for educational and portfolio purposes only.
# 0003 Use rFMS-Aligned Model

## Status

Accepted

## Implementation Status

Planned

## Context

TruckFleet is inspired by commercial fleet-management concepts and publicly documented vehicle-data terminology.

The project does not use real OEM vehicle data or real Scania APIs. It also does not attempt to copy proprietary systems, private schemas, or private scoring algorithms.

Later parts of the project will include simulated vehicle telemetry and vehicle-status concepts.

## Decision

TruckFleet will use an rFMS-aligned internal model when vehicle telemetry is introduced.

This means the project can use public industry concepts such as vehicle status, accumulated values, driver information, and operational data without claiming official integration with any manufacturer.

## Consequences

This keeps the domain model realistic for commercial fleet operations while preserving a clear legal and technical boundary.

The project can demonstrate understanding of connected-vehicle backend concepts without requiring access to real vehicle data.

Any future provider for OEM data must be treated as an adapter behind the project boundary, not as the core domain model itself.

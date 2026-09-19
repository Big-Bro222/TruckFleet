# 0004 Use SignalR

## Status

Accepted

## Implementation Status

Planned

## Context

TruckFleet will later include near real-time fleet-position and vehicle-status updates.

The Week 1 project does not implement real-time communication. SignalR will become relevant when simulated telemetry and live status views are added.

## Decision

TruckFleet will use SignalR when real-time browser updates are introduced.

SignalR is selected because it is the standard ASP.NET Core option for server-to-client real-time communication and fits naturally with the planned .NET backend stack.

## Consequences

SignalR allows the project to support live updates without introducing a separate real-time framework such as Socket.IO.

The project can keep REST APIs for request-response workflows and use SignalR for push-based updates.

Real-time communication is deferred until the later fleet-position and telemetry weeks.

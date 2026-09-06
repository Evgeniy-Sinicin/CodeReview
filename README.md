# CodeReview.Plane

This project contrasts a deliberately problematic `Plane` implementation in [`Bad`](Bad) with a cleaner design in [`Good`](Good).

`Bad` is not production code. It is kept as a review exercise: each issue represents a common design, concurrency, or reliability problem.

## Structure

```text
Bad/   Original implementation with intentional issues
Good/  Refactored example with separated responsibilities
```

## Why `Good` is better

| Area | `Bad` | `Good` |
|---|---|---|
| Async API | Uses `async void`; callers cannot await completion or reliably handle failures. | Async operations return `Task` or `Task<T>`. |
| Synchronization | Holds `Monitor` across `await`; it can resume on another thread and the lock is not released on success. | No thread lock is held across `await`. Persistent concurrency belongs in the repository. |
| Lock scope | A `static` lock serializes coordinate checks for every plane. | No global lock shared by unrelated planes. |
| Passengers | A mutable public `ConcurrentDictionary` is exposed. | A private dictionary is exposed as `IReadOnlyCollection<Passenger>`. |
| Passenger key | A local `int` counter can race, overflow, and overwrite values. | `DocumentId` is the stable unique key; `TryAdd` rejects duplicates. |
| Registration result | `Register` provides no result to its caller. | `RegistrationResult` describes success or the expected reason for rejection. |
| Flight rules | A flight can start repeatedly or from an invalid state. | `FlightStatus`, capacity, and transition checks protect domain invariants. |
| Coordinates | Coordinates are represented by an unvalidated string. | `Coordinate` is a value type with latitude/longitude validation. |
| Responsibilities | `Plane` stores state, calls navigation, writes the database, serializes JSON, and sends Kafka messages. | `Plane` holds state and business rules; `FlightService` coordinates a use case; infrastructure is behind interfaces. |
| Dependencies | The domain class directly calls static concrete services. | Dependencies use `IPlaneRepository`, `ICoordinateProvider`, `IOutbox`, and `IFlightEventPublisher`. |
| Serialization | The domain model depends on Newtonsoft.Json and is sent as a transport payload. | `FlightStartedMessage` is a separate transport DTO. The domain has no JSON dependency. |
| Database + Kafka | A database write may succeed while Kafka publishing fails. | A transactional outbox persists state and events together; `OutboxPublisher` publishes later and marks successful messages. |
| Testability | Static dependencies make substitutions difficult. | Interfaces allow fake or mock implementations in unit tests. |

## Good design flow

```text
FlightService.StartFlightAsync
    -> load Plane through IPlaneRepository
    -> Plane.Start validates state and changes it to InFlight
    -> create FlightStarted event
    -> save Plane and event in one database transaction (outbox)

OutboxPublisher
    -> reads unpublished outbox messages
    -> publishes FlightStartedMessage
    -> marks the message as published after broker acknowledgement
```

The publisher can run from a background worker. If the process fails after the broker accepts an event but before the outbox row is marked published, the event may be sent again. Consumers should therefore be idempotent.

## Intentional infrastructure stubs

The `NotImplemented*` classes in `Good` represent database, coordinate-provider, outbox, and message-broker implementations. They intentionally throw `NotImplementedException`; the project demonstrates boundaries and responsibilities, not actual infrastructure integration.

## Build

```powershell
dotnet build CodeReview.Plane.slnx
```

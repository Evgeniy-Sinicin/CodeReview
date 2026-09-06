# Plane

This project contrasts a deliberately problematic implementation in [`Bad`](Bad) with a cleaner design in [`Good`](Good).

`Bad` is a review exercise, not production code. Each issue represents a common design, concurrency, or reliability problem.

## Why `Good` is better

| Area | `Bad` | `Good` |
|---|---|---|
| Async API | Uses `async void`. | Returns `Task` or `Task<T>`. |
| Synchronization | Holds `Monitor` across `await`. | Does not hold a thread lock across `await`. |
| Lock scope | One `static` lock affects every plane. | No global lock shared by unrelated planes. |
| Passengers | Exposes a mutable public dictionary. | Exposes a private collection as `IReadOnlyCollection<Passenger>`. |
| Passenger key | Uses a racing, overflowing local counter. | Uses `DocumentId` and `TryAdd` to reject duplicates. |
| Registration | Does not report its result. | Returns `RegistrationResult`. |
| Flight rules | Allows invalid or repeated starts. | Validates `FlightStatus`, capacity, and passenger count. |
| Coordinates | Uses an unvalidated string. | Uses a validated `Coordinate` value object. |
| Responsibilities | Mixes state, navigation, database, JSON, and Kafka. | Separates domain rules, use-case orchestration, and infrastructure. |
| Dependencies | Direct static concrete calls. | Interfaces allow substitution in tests. |
| Serialization | Serializes the domain model directly. | Uses `FlightStartedMessage`, a separate transport DTO. |
| Database + Kafka | Can leave a partial result. | Uses a transactional outbox and retryable publishing. |

## Flow

```text
FlightService.StartFlightAsync
    -> load Plane
    -> Plane.Start validates and changes state
    -> create FlightStarted
    -> transaction: save Plane + outbox event

OutboxPublisher
    -> read unpublished events
    -> publish FlightStartedMessage
    -> mark event published after acknowledgement
```

The `NotImplemented*` classes intentionally throw `NotImplementedException`. They define infrastructure boundaries without implementing a database, message broker, or coordinate provider.

## Build

```powershell
dotnet build Plane.csproj
```

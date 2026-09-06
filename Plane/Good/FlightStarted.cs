namespace CodeReview.Plane.Good;
public sealed record FlightStarted(Guid FlightId, IReadOnlyList<string> PassengerDocumentIds) : IDomainEvent;

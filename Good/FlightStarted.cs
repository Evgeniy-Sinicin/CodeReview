namespace CodeReview.Good;
public sealed record FlightStarted(Guid FlightId, IReadOnlyList<string> PassengerDocumentIds) : IDomainEvent;

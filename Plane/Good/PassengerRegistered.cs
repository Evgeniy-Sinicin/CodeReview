namespace CodeReview.Plane.Good;
public sealed record PassengerRegistered(Guid FlightId, string PassengerDocumentId) : IDomainEvent;

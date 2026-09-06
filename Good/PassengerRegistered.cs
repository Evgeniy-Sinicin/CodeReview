namespace CodeReview.Good;
public sealed record PassengerRegistered(Guid FlightId, string PassengerDocumentId) : IDomainEvent;

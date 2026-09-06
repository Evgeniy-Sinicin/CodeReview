namespace CodeReview.Good;
public sealed record FlightStartedMessage(Guid FlightId, IReadOnlyList<string> PassengerDocumentIds);

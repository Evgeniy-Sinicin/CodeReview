namespace CodeReview.Plane.Good;
public sealed record FlightStartedMessage(Guid FlightId, IReadOnlyList<string> PassengerDocumentIds);

namespace CodeReview.Plane.Good;
public sealed record OutboxMessage(Guid Id, IDomainEvent Event);

namespace CodeReview.Good;
public sealed record OutboxMessage(Guid Id, IDomainEvent Event);

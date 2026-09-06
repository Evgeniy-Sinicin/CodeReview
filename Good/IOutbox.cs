namespace CodeReview.Good;
public interface IOutbox
{
    Task<IReadOnlyList<OutboxMessage>> GetUnpublishedAsync(CancellationToken cancellationToken);
    Task MarkPublishedAsync(Guid messageId, CancellationToken cancellationToken);
}

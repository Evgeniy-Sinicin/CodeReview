namespace CodeReview.Good;
public sealed class NotImplementedOutbox : IOutbox
{
    public Task<IReadOnlyList<OutboxMessage>> GetUnpublishedAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task MarkPublishedAsync(Guid messageId, CancellationToken cancellationToken) => throw new NotImplementedException();
}

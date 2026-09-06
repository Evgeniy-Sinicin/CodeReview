namespace CodeReview.Plane.Good;
public sealed class NotImplementedPlaneRepository : IPlaneRepository
{
    public Task<Plane> GetAsync(Guid flightId, CancellationToken cancellationToken) => throw new NotImplementedException();

    public Task SaveWithOutboxAsync(Plane plane, IReadOnlyList<IDomainEvent> events, CancellationToken cancellationToken) => throw new NotImplementedException();
}

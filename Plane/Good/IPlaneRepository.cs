namespace CodeReview.Plane.Good;
public interface IPlaneRepository
{
    Task<Plane> GetAsync(Guid flightId, CancellationToken cancellationToken);
    Task SaveWithOutboxAsync(Plane plane, IReadOnlyList<IDomainEvent> events, CancellationToken cancellationToken);
}

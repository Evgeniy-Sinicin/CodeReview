namespace CodeReview.Plane.Good;
public sealed class NotImplementedCoordinateProvider : ICoordinateProvider
{
    public Task<Coordinate> GetCoordinateAsync(Guid flightId, CancellationToken cancellationToken) => throw new NotImplementedException();
}

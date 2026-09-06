namespace CodeReview.Plane.Good;
public interface ICoordinateProvider { Task<Coordinate> GetCoordinateAsync(Guid flightId, CancellationToken cancellationToken); }

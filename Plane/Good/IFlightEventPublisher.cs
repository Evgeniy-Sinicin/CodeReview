namespace CodeReview.Plane.Good;
public interface IFlightEventPublisher { Task PublishAsync(FlightStartedMessage message, CancellationToken cancellationToken); }

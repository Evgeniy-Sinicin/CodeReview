namespace CodeReview.Good;
public interface IFlightEventPublisher { Task PublishAsync(FlightStartedMessage message, CancellationToken cancellationToken); }

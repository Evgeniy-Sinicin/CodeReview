namespace CodeReview.Good;
public sealed class NotImplementedFlightEventPublisher : IFlightEventPublisher
{
    public Task PublishAsync(FlightStartedMessage message, CancellationToken cancellationToken) => throw new NotImplementedException();
}

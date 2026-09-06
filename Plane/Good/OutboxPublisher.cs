namespace CodeReview.Plane.Good;

public sealed class OutboxPublisher(IOutbox outbox, IFlightEventPublisher publisher)
{
    public async Task PublishPendingAsync(CancellationToken cancellationToken = default)
    {
        foreach (var message in await outbox.GetUnpublishedAsync(cancellationToken))
        {
            if (message.Event is not FlightStarted started)
                continue;

            await publisher.PublishAsync(
                new FlightStartedMessage(started.FlightId, started.PassengerDocumentIds),
                cancellationToken);
            await outbox.MarkPublishedAsync(message.Id, cancellationToken);
        }
    }
}

namespace CodeReview.Good;

public sealed class FlightService(IPlaneRepository planes, ICoordinateProvider coordinates)
{
    public async Task<RegistrationResult> RegisterAsync(Guid flightId, Passenger passenger, CancellationToken cancellationToken = default)
    {
        var plane = await planes.GetAsync(flightId, cancellationToken);
        var result = plane.Register(passenger);

        if (result == RegistrationResult.Success)
            await planes.SaveWithOutboxAsync(
                plane,
                [new PassengerRegistered(plane.Id, passenger.DocumentId)],
                cancellationToken);

        return result;
    }

    public async Task CheckCoordinateAsync(Guid flightId, CancellationToken cancellationToken = default)
    {
        var coordinate = await coordinates.GetCoordinateAsync(flightId, cancellationToken);
        var plane = await planes.GetAsync(flightId, cancellationToken);
        plane.UpdateCoordinate(coordinate);
        await planes.SaveWithOutboxAsync(plane, [], cancellationToken);
    }

    public async Task StartFlightAsync(Guid flightId, CancellationToken cancellationToken = default)
    {
        var plane = await planes.GetAsync(flightId, cancellationToken);
        plane.Start();
        await planes.SaveWithOutboxAsync(
            plane,
            [new FlightStarted(plane.Id, plane.Passengers.Select(x => x.DocumentId).ToArray())],
            cancellationToken);
    }
}

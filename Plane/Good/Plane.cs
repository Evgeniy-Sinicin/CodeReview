namespace CodeReview.Plane.Good;

public sealed class Plane
{
    private readonly Dictionary<string, Passenger> _passengers = new();

    public Plane(Guid id, Pilot pilot, int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity));

        Id = id;
        Pilot = pilot ?? throw new ArgumentNullException(nameof(pilot));
        Capacity = capacity;
    }

    public Guid Id { get; }
    public Pilot Pilot { get; private set; }
    public int Capacity { get; }
    public FlightStatus Status { get; private set; } = FlightStatus.Boarding;
    public Coordinate? Coordinate { get; private set; }
    public IReadOnlyCollection<Passenger> Passengers => _passengers.Values;

    public RegistrationResult Register(Passenger passenger)
    {
        ArgumentNullException.ThrowIfNull(passenger);

        if (Status != FlightStatus.Boarding)
            return RegistrationResult.RegistrationClosed;

        if (_passengers.Count >= Capacity)
            return RegistrationResult.NoAvailableSeats;

        if (!_passengers.TryAdd(passenger.DocumentId, passenger))
            return RegistrationResult.DuplicatePassenger;

        return RegistrationResult.Success;
    }

    public void ChangePilot(Pilot pilot) => Pilot = pilot ?? throw new ArgumentNullException(nameof(pilot));
    public void UpdateCoordinate(Coordinate coordinate) => Coordinate = coordinate ?? throw new ArgumentNullException(nameof(coordinate));

    public void Start()
    {
        if (Status != FlightStatus.Boarding)
            throw new InvalidOperationException($"Cannot start flight from {Status}.");

        if (_passengers.Count == 0)
            throw new InvalidOperationException("Cannot start flight without passengers.");

        Status = FlightStatus.InFlight;
    }
}

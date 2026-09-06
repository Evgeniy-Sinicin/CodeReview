namespace CodeReview.Good;
public sealed record Coordinate
{
    public Coordinate(decimal latitude, decimal longitude)
    {
        if (latitude is < -90 or > 90) throw new ArgumentOutOfRangeException(nameof(latitude));
        if (longitude is < -180 or > 180) throw new ArgumentOutOfRangeException(nameof(longitude));
        Latitude = latitude; Longitude = longitude;
    }
    public decimal Latitude { get; }
    public decimal Longitude { get; }
}

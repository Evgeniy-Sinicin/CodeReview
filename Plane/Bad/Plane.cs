using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace CodeReview.Plane.Bad;

public class Plane
{
    private int FlightId;
    private Person Pilot;
    private int _currentNumber = 0;
    private string coordinate;

    public Plane(Person p, int id)
    {
        Pilot = p;
        FlightId = id;
        Passengers = new ConcurrentDictionary<int, Person>();
    }

    public void Register(Person p)
    {
        Passengers[_currentNumber++] = p;
    }

    private static object _sync = new object();

    public async void CheckCoordinate()
    {
        Monitor.Enter(_sync);
        try
        {
            string temp = await Navigator.GetCoordinate();
            if (!coordinate.Equals(temp))
            {
                coordinate = temp;
            }
        }
        catch (Exception e)
        {
            Monitor.Exit(_sync);
        }
    }

    public void ChangePilot(string fn, string ln, string doc)
    {
        Pilot.FirstName = fn;
        Pilot.LastName = ln;
    }

    public async void StartFlight()
    {
        await FlightDb.Start(FlightId, JsonConvert.SerializeObject(Passengers));
        await FlightKafkaQueue.SendStart(
            FlightId,
            JsonConvert.SerializeObject(Passengers)
        );
    }

    public ConcurrentDictionary<int, Person> Passengers { get; set; }
}

public class Person
{
    public string DocumentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

internal class FlightKafkaQueue
{
    internal static async Task SendStart(int flightId, string v)
    {
        throw new NotImplementedException();
    }
}

internal class FlightDb
{
    internal static async Task Start(int flightId, string v)
    {
        throw new NotImplementedException();
    }
}

internal class Navigator
{
    internal static async Task<string> GetCoordinate()
    {
        throw new NotImplementedException();
    }
}

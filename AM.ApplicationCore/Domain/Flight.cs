namespace AM.ApplicationCore.Domain;

public class Flight
{

    public int FlightId { get; set; }
    public string Destination { get; set; }
    public DateTime EffectiveArrival{ get; set; }
    public string Departure{ get; set; }
    public DateTime FlightDate{ get; set; }
    public int EstimateDuration{ get; set; }
    
    
    //Objets de navigation
    
    public Plane Plane{ get; set; }
    public ICollection<Passenger> Passengers{ get; set; }

    public override string ToString()
    {
        return "Departure: " + Departure;
    }
}
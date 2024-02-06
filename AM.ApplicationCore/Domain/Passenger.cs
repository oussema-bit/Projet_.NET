namespace AM.ApplicationCore.Domain;

public class Passenger
{
    public DateTime BirthDate{ get; set; }
    public int PassportNumber{ get; set; }
    public string EmailAddress { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int TelNumber{ get; set; }
    
    
    public ICollection<Flight> Flights{ get; set; }
}
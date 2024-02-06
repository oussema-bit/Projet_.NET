namespace AM.ApplicationCore.Domain;

public class Staff:Passenger
{
    public DateTime EmployementDate{ get; set; }
    public string Function { get; set; } = "";
    public double Salary{ get; set; }
}
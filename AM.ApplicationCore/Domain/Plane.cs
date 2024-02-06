namespace AM.ApplicationCore.Domain;

public class Plane
{
  public enum PlaneType
  {
    Boeing,Airbus
  }
  
  //Property
  public int PlaneId { get; set; }
  public int Capacity { get; set; } = 0;//valeur par defaut ajoute =val
  public DateTime ManufactureDate { get; set; }

  public Flight Flight{ get; set; }
  
}
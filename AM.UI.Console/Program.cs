// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");
//création d'un objet à travers le constructeur par défaut
Plane p = new Plane();
p.Capacity = 100;
Console.WriteLine(p.Capacity);
p.ManufactureDate = DateTime.Now;
p.PlaneType = PlaneType.Boeing;

//Flight f = new Flight("Paris","Tunis",new DateTime(2024,10,3,12,1,1)
//    , new DateTime(2024, 10, 3, 13, 1, 1),120);
//création d'un objet à travers l'initialiseur d'objets
Flight f = new Flight() { Departure = "Tunis" ,
    Destination = "Paris",
    EstimatedDuration=120,
    FlightDate= new DateTime(2024, 10, 3, 12, 1, 1),
    EffectiveArrival= new DateTime(2024, 10, 3, 13, 1, 1)
};
//ToString
Console.WriteLine(f);
Console.WriteLine("*****CheckProfile*******");
Passenger p1 = new Passenger() {FirstName="Amina"
    ,LastName="Aoun"
    ,EmailAdress="amina.aoun@esprit.tn"};
Console.WriteLine(p1.CheckProfile("Amina","Aoun"));
Console.WriteLine(p1.CheckProfile("Amina", "Aoun","a.gmail"));
Console.WriteLine( "**********Passenger Type********");
Staff s1= new Staff();
Traveller t1 = new Traveller();
p1.PassengerType();
s1.PassengerType();
t1.PassengerType();
FlightMethods fm = new FlightMethods();
Console.WriteLine("**********GetFlightDates********");
fm.Flights = TestData.listFlights;
foreach(DateTime d in fm.GetFlightDates("Paris"))
    Console.WriteLine(d);
Console.WriteLine("********** GetFlights ********");
fm.GetFlights("EstimatedDuration", "105");

Console.WriteLine("********** ShowFlightDetails ********");
fm.ShowFlightDetails(TestData.BoingPlane);

Console.WriteLine("********** ProgrammedFlightNumber ********");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2021,12,31)));
Console.WriteLine("********** DurationAverage ********");
Console.WriteLine(fm.DurationAverage("Madrid"));
Console.WriteLine("********** OrderedDurationFlights ********");
IEnumerable<Flight> orderedDuration=fm.OrderedDurationFlights();
foreach (var duration in orderedDuration)
{
    Console.WriteLine(duration);
}
Console.WriteLine("********** SeniorTravellers ********");
foreach (var traveller in fm.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(traveller.BirthDate);
}

Console.WriteLine("********** DestinationGroupedFlights ********");
fm.afficherGroupedFlights(fm.DestinationGroupedFlights());

Console.WriteLine("********** FlightDetailsDel ********");
fm.FlightDetailsDel(TestData.BoingPlane);


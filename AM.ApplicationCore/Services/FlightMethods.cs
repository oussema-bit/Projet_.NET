using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods:IFlightMethods
    {
      public List<Flight> Flights=new List<Flight>();
      public Action<Plane> FlightDetailsDel;
      public Func<string, double> DurationAverageDel;

      public FlightMethods()
      {
          //FlightDetailsDel = ShowFlightDetails; 1er Methode
          FlightDetailsDel = pl =>
          {
              var res = from f in Flights
                  where f.Plane == pl
                  select new { f.FlightDate, f.Destination };
              foreach (var i in res)
              {
                  Console.WriteLine(i);
              }
          };
          
          //DurationAverageDel = DurationAverage; 1er Methode
          DurationAverageDel = dest =>
          {
              var res = from f in Flights
                  where f.Destination == dest
                  select f.EstimatedDuration;
              return res.Average();
          };
      }
      
      public List<DateTime> GetFlightDates(string destination)
        {
            //Methode classic 1
            /*List<DateTime> dates = new List<DateTime>();
            foreach(Flight f in Flights)
            {
                if (f.Destination == destination)
                    dates.Add(f.FlightDate);
            }
            return dates;*/ 
            // Best practice is to use LINQ

            /*List<DateTime> dates = (from f in Flights
                where f.Destination == destination
                select f.FlightDate).ToList();*/ //LINQ
            
            // Even better is to have the method return IEnumerable
            List<DateTime> dates = Flights.Where(f => f.Destination == destination)
                .Select(f => f.FlightDate).ToList(); //Lambda is better
            return dates;
        } //Lambda + LINQ

        public void GetFlights(string filterType, string filterValue)
        {
            /*switch (filterType)
            {
                case "Destination":
                        foreach(Flight f in Flights)
                        if(f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                break;
                case "Departure":
                    foreach (Flight f in Flights)
                        if (f.Departure.Equals(filterValue))
                            Console.WriteLine(f);
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                        if (f.FlightDate.Equals(DateTime.Parse(filterValue)))
                            Console.WriteLine(f);
                    break;
                case "EstimatedDuration":
                    foreach (Flight f in Flights)
                        if (f.EstimatedDuration.Equals(int.Parse(filterValue)))
                            Console.WriteLine(f);
                    break;
                default: Console.WriteLine("Filtre introuvable");
                    break;

            }*/
        }

        public void ShowFlightDetails(Plane plane)
        {
            var res = from f in Flights
                where f.Plane == plane
                select new { f.FlightDate, f.Destination };
            //On ne peut pas retourner une variable de type var !!
            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var res = from f in Flights 
                where (f.FlightDate-startDate).TotalDays<= 7 && (f.FlightDate-startDate).TotalDays >0
                    select f;
            //DateTime.Compare(d1,d2) 0 si d1==d2 | < 0 si d1<d2 | > 0 si d1>d2
            //TimeSpan ==> d1-d2
            var req = Flights.Where(f =>
                (f.FlightDate - startDate).TotalDays <= 7 && (f.FlightDate - startDate).TotalDays > 0);
            return req.Count(); //Lambda
            // return res.Count(); //LINQ
        } //Lambda + LINQ

        public double DurationAverage(string destination)
        {
            /*var res = from f in Flights
                where f.Destination == destination
                select f.EstimatedDuration;*/ //LINQ
            var res = Flights.Where(f => f.Destination == destination)
                .Average(f => f.EstimatedDuration);
            return res; //Lambda
            //return res.Average(); //LINQ
        } //Lambda + LINQ

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var res = from f in Flights
                orderby f.EstimatedDuration
                select f;
            var req = Flights.OrderByDescending(f => f.EstimatedDuration);
            return req; //Lambda
            // return res; //LINQ
        } //Lambda + LINQ

        public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            /*var res = from t in flight.Passengers.OfType<Traveller>()
                orderby t.BirthDate
                select t;*/ //LINQ
            
            var req = flight.Passengers.OfType<Traveller>().OrderBy(f => f.BirthDate);
            return req.Take(3); //Lambda
            
            //return res.Take(3); //LINQ
            //Skip(3) ==> ignorer les 3 premiers elements
        } //Lambda + LINQ

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            /*var req = from f in Flights
                group f by f.Destination;*/ //LINQ
            var req2 = Flights.GroupBy(f => f.Destination); //Lambda
            
            return req2; //Lambda
            //return req; //LINQ
        }//Lambda + LINQ

        public void afficherGroupedFlights(IEnumerable <IGrouping<string, Flight>> g)
        {
            foreach (var group in g)
            {
                Console.WriteLine("Destination "+group.Key);
                foreach (var flight in group)
                {
                    Console.WriteLine("Décollage :"+flight.FlightDate);
                }
            }
        }


        
    }
}

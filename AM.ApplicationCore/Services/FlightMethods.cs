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

            List<DateTime> dates = (from f in Flights
                where f.Destination == destination
                select f.FlightDate).ToList();
            
            // Even better is to have the method return IEnumerable

            return dates;
        }

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
            
            return res.Count();
        }

        public double DurationAverage(string destination)
        {
            var res = from f in Flights
                where f.Destination == destination
                select f.EstimatedDuration;
            return res.Average();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var res = from f in Flights
                orderby f.EstimatedDuration
                select f;
            return res;
        }

        public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            var res = from t in flight.Passengers.OfType<Traveller>()
                orderby t.BirthDate
                select t;
            return res.Take(3);
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                group f by f.Destination;
            
            return req;
        }

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

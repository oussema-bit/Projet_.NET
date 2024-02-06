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

        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach(Flight f in Flights)
            {
                if (f.Destination == destination)
                    dates.Add(f.FlightDate);
            }
            return dates;
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
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

            }
        }
    }
}

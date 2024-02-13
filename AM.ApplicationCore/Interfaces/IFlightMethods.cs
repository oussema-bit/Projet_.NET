using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
       List<DateTime> GetFlightDates(string destination);
       void GetFlights(string filterType, string filterValue);

       public void ShowFlightDetails(Plane plane);

       public int ProgrammedFlightNumber(DateTime startDate);

       public double DurationAverage(string destination);

       public IEnumerable<Flight> OrderedDurationFlights();

       public IEnumerable<Passenger> SeniorTravellers(Flight flight);

       public IEnumerable <IGrouping<string, Flight>> DestinationGroupedFlights();

       public void afficherGroupedFlights(IEnumerable <IGrouping<string, Flight>> g);

    }
}

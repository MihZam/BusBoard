using System.Collections.Generic;
using BusBoard.ConsoleApp;

namespace BusBoard.Web.Models
{
    public class BusStopsAndIncomingBuses
    {
        public BusStopsAndIncomingBuses(string naptanId, List<Bus> buses)
        {
            this.NaptanId = naptanId;
            this.Buses = buses;
        }
        
        public string NaptanId { get;  }
        public List<Bus> Buses { get; }
    }
}
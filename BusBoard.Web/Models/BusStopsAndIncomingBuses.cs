using System.Collections.Generic;
using BusBoard.ConsoleApp;

namespace BusBoard.Web.Models
{
    public class BusStopsAndIncomingBuses
    {
        public BusStopsAndIncomingBuses(string naptanId, List<Bus> buses, string commonName)
        {
            this.NaptanId = naptanId;
            this.CommonName = commonName;
            this.Buses = buses;
        }
        
        public string NaptanId { get;  }
        public string CommonName { get; }
        public List<Bus> Buses { get; }
    }
}
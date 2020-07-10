using System.Collections.Generic;
using BusBoard.ConsoleApp;

namespace BusBoard.Web.Models
{
    public class BusStopArrivals
    {
        public BusStopArrivals(string naptanId, List<Bus> buses)
        {
            this.naptanId = naptanId;
            this.buses = buses;
        }
        
        public string naptanId { get; }
        public List<Bus> buses { get; }
    }
}
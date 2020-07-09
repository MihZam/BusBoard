using System;

namespace BusBoard.ConsoleApp
{
    public class Bus
    {
        public string lineName { get; set; }
        public DateTime expectedArrival { get; set; }
        public int timeToStation { get; set; }
    }
}
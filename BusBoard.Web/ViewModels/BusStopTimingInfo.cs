using System.Collections.Generic;
using BusBoard.ConsoleApp;

namespace BusBoard.Web.ViewModels
{
    public class BusStopTimingInfo
    {
        public BusStopTimingInfo(List<Bus> buses)
        {
            Buses = buses;
        }

        public List<Bus> Buses { get; set; }
    }
}
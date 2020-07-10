using System.Collections.Generic;
using BusBoard.ConsoleApp;

namespace BusBoard.Web.ViewModels
{
    public class BusStopInfo
    {
        public BusStopInfo(List<BusStop> stops)
        {
            Stops = stops;
        }

        public List<BusStop> Stops { get; set; }
    }
}
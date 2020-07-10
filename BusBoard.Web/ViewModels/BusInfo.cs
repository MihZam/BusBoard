using System.Collections.Generic;
using BusBoard.ConsoleApp;
using BusBoard.Web.Models;

namespace BusBoard.Web.ViewModels
{
    public class BusInfo
    {
        public BusInfo(List<BusStopsAndIncomingBuses> localStops)
        {
            LocalStops = localStops;
        }

        public List<BusStopsAndIncomingBuses> LocalStops { get; }
    }
}
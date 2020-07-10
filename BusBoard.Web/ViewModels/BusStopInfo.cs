using System.Collections.Generic;
using BusBoard.ConsoleApp;
using BusBoard.Web.Models;

namespace BusBoard.Web.ViewModels
{
    public class BusStopInfo
    {
        public BusStopInfo(List<BusStopArrivals> stops)
        {
            Stops = stops;
        }

        public List<BusStopArrivals> Stops { get; }
    }
}
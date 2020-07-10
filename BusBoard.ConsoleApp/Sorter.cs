using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace BusBoard.ConsoleApp
{
    public class Sorter
    {
        public List<BusStop> sortByDistance(List<BusStop> stops, Postcode postcode)
        {
            foreach (var stop in stops)
            {
                stop.distance = Math.Pow((double.Parse(stop.lat) - double.Parse(postcode.latitude)), 2) +
                                Math.Pow(double.Parse(stop.lon) - double.Parse(postcode.longitude), 2);
            }
            stops.Sort((x,y) => x.distance.CompareTo(y.distance));
            return stops;
        }

        public List<Bus> sortByTime(List<Bus> buses)
        {
            buses.Sort((x,y) => x.timeToStation.CompareTo(y.timeToStation));
            return buses;
        }
    }
}
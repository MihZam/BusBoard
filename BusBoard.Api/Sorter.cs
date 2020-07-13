using System;
using System.Collections.Generic;
using System.Linq;
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
                                Math.Pow((double.Parse(stop.lon) - double.Parse(postcode.longitude))*Math.Cos(51.5), 2);
            }
            stops.Sort((x,y) => x.distance.CompareTo(y.distance));
            return stops;
        }

        public List<Bus> sortByTime(List<Bus> buses)
        {
            buses.Sort((x,y) => x.timeToStation.CompareTo(y.timeToStation));
            return buses;
        }

        public List<Bus> getFirstNBuses(List<Bus> buses, int N)
        {
            var result = new List<Bus>();
            for (var i = 0; i < N; i++)
            {
                result.Add(buses[i]);
            }

            return result;
        }
    }
}
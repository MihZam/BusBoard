using System;
using System.Collections.Generic;

namespace BusBoard.ConsoleApp
{
    public class Formatter
    {
        public string GetFormatOfNextNBuses(List<Bus> upcomingBuses, int numberOfBuses)
        {
            string text = "";
            for (var i = 0; i < numberOfBuses; i++)
            {
                if (i >= upcomingBuses.Count)
                {
                    break;
                }
                var bus = upcomingBuses[i];
                var minutes = Decimal.Floor(bus.timeToStation / 60);
                string end;
                if (minutes == 0)
                {
                    end = "Due";
                } else if (minutes == 1)
                {
                    end = "1 min";
                } else
                {
                    end = minutes + " mins";
                }
                text += $"Bus {bus.lineName}  ---  {end}\n";
            }

            return text;
        }
    }
}
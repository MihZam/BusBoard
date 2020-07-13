using System;
using System.Collections.Generic;

namespace BusBoard.ConsoleApp
{
    public class Formatter
    {

        public static string FormatTime(int timeInSeconds)
        {
            var minutes = Decimal.Floor(timeInSeconds / 60);
            if (minutes == 0)
            {
                return "Due";
            }

            if (minutes == 1)
            {
                return "1 min";
            }

            return minutes + " mins";
        }

        public static string FormatBusLine(string line, int time)
        {
            return line + " --- " + FormatTime(time);
        }

        public static string FormatStopName(string id, string name)
        {
            return ($"{name} ({id})");
        }
        
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
                
                text += $"Bus {bus.lineName}  ---  {FormatTime(bus.timeToStation)}\n";
            }

            return text;
        }
    }
}
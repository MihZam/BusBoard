using System;
using System.Collections.Generic;

namespace BusBoard.ConsoleApp
{
    public class ConsoleOutput
    {
        public void WelcomeToBusBoard()
        {
            Console.WriteLine("Welcome to BusBoard!");
        }
        
        public void printNextNBuses(List<Bus> upcomingBuses, int numberOfBuses)
        {
            for (var i = 0; i < numberOfBuses; i++)
            {
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
                Console.WriteLine($"Bus {bus.lineName}  ---  {end}");
                Console.WriteLine(bus.expectedArrival);
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace BusBoard.ConsoleApp
{
    public class ConsoleOutput
    {
        public void printNext5Buses(List<Bus> upcomingBuses)
        {
            for (var i = 0; i < 5; i++)
            {
                var bus = upcomingBuses[i];
                Console.WriteLine($"Bus {bus.lineName}  ---  {Decimal.Floor(bus.timeToStation / 60)} mins");
                Console.WriteLine(bus.expectedArrival);
            }
        }
    }
}
using System;

namespace BusBoard.ConsoleApp
{
    public class UserInterface
    {
        public string AskForBusStop()
        {
            Console.WriteLine("Enter your bus stop ID: ");
            return Console.ReadLine();
        }

        public string AskForPostCode()
        {
            Console.WriteLine("Enter your postcode: ");
            return Console.ReadLine();
        }
    }
}
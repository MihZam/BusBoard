using System;

namespace BusBoard.ConsoleApp
{
    public class UserInterface
    {
        public void WelcomeToBusBoard()
        {
            Console.WriteLine("Welcome to BusBoard!");
        }

        public string AskForBusStop()
        {
            Console.WriteLine("Enter your bus stop ID: ");
            return Console.ReadLine();
        }
    }
}
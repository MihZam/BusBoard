using System;
using System.Net;

namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      // 490008660N    NW5 1TL
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
      var tfLReceiver = new DataReceiverFromTfL();
      var postcodeReceiver = new DataReceiverFromPostCodes();
      var ui = new UserInterface();
      var output = new ConsoleOutput();
      
      output.WelcomeToBusBoard();

      var postCodeInput = ui.AskForPostCode();
      var postCode = postcodeReceiver.GetPostCodeData(postCodeInput);
      var closestBusStops = tfLReceiver.GetBusStops(postCode.longitude, postCode.latitude);
      
      foreach (var stop in closestBusStops)
        // Need to change this so that only the two nearest are printed
      {
        Console.WriteLine("Bus stop ID: " + stop.naptanId);
        
        var upcomingBuses = tfLReceiver.GetBusArrivals(stop.naptanId);
        upcomingBuses.Sort((x,y) => x.timeToStation.CompareTo(y.timeToStation));
        output.printNextNBuses(upcomingBuses, 5);
        
        Console.WriteLine();

      }
    }
  }
}

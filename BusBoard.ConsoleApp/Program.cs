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
      var sorter = new Sorter();
      
      output.WelcomeToBusBoard();

      var postcodeInput = ui.AskForPostcode();
      var postcode = postcodeReceiver.GetPostcodeData(postcodeInput);
      var closestBusStops = tfLReceiver.GetBusStops(postcode.longitude, postcode.latitude);
      closestBusStops = sorter.sortByDistance(closestBusStops, postcode);
      
      for (var i = 0; i < 2; i++)
      {
        var stop = closestBusStops[i];
        Console.WriteLine("Bus stop ID: " + stop.naptanId);
        
        var upcomingBuses = tfLReceiver.GetBusArrivals(stop.naptanId);
        upcomingBuses = sorter.sortByTime(upcomingBuses);
        output.printNextNBuses(upcomingBuses, 5);
        
        Console.WriteLine();

      }
    }
  }
}

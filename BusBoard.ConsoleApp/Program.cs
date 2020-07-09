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
      var dr = new DataReceiverFromTfL();
      var pcdr = new DataReceiverFromPostCodes();
      var ui = new UserInterface();
      var output = new ConsoleOutput();
      

      var postCodeInput = ui.AskForPostCode();
      var postCode = pcdr.GetPostCodeData(postCodeInput);
      var stopss = dr.GetBusStops(postCode.longitude, postCode.latitude);
      foreach (var stopp in stopss)
      {
        Console.WriteLine(stopp.naptanId);
      }

      var busStop = ui.AskForBusStop();
      var upcomingBuses = dr.GetBusArrivals(busStop);

      upcomingBuses.Sort((x,y) => x.timeToStation.CompareTo(y.timeToStation));
      
      output.printNext5Buses(upcomingBuses);
    }
  }
}

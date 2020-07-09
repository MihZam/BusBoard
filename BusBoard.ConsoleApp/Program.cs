using System.Net;

namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      // 490008660N
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
      var dr = new DataReceiverFromTfL();
      var ui = new UserInterface();
      var output = new ConsoleOutput();
      var busStop = ui.AskForBusStop();

      var upcomingBuses = dr.GetBusArrivals(busStop);
      
      upcomingBuses.Sort((x,y) => x.timeToStation.CompareTo(y.timeToStation));
      
      output.printNext5Buses(upcomingBuses);
    }
  }
}

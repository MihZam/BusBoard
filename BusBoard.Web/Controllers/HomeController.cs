using System.Collections.Generic;
using System.Web.Mvc;
using BusBoard.ConsoleApp;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;

namespace BusBoard.Web.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public ActionResult BusInfo(PostcodeSelection selection)
      // Add some properties to the BusInfo view model with the data you want to render on the page.
      // Write code here to populate the view model with info from the APIs.
      // Then modify the view (in Views/Home/BusInfo.cshtml) to render upcoming buses.
    {
      // Makes objects to communicate with APIs
      var postcodeReceiver = new DataReceiverFromPostcodes();
      var tfLReceiver = new DataReceiverFromTfL();
      
      // Gets the postcode data from the input
      var postcode = postcodeReceiver.GetPostcodeData(selection.Postcode);
      
      // Gets the closest 2 stops
      var stops = tfLReceiver.GetBusStops(postcode.longitude, postcode.latitude);
      List<BusStopsAndIncomingBuses> up = new List<BusStopsAndIncomingBuses>();
      
      foreach (var stop in stops)
      {
        var sorter = new Sorter();
      
        // gets the upcoming buses
        var upcomingBuses = tfLReceiver.GetBusArrivals(stop.naptanId);
        var upcomingBusesSorted = sorter.sortByTime(upcomingBuses);
        
        // adds the combined bus stop name & upcoming buses object to a list
        up.Add(new BusStopsAndIncomingBuses(stop.naptanId, upcomingBusesSorted));
      }
      
      // sends the list off to BusStopInfo
      var info = new BusInfo(up);
      return View(info);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Information about this site";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Contact us!";

      return View();
    }
  }
}

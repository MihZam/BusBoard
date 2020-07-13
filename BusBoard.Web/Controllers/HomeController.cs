using System;
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
    {
      Response.AddHeader("Refresh", "30");
      
      var postcodeReceiver = new DataReceiverFromPostcodes();
      var tfLReceiver = new DataReceiverFromTfL();
      var sorter = new Sorter();
      
      var postcode = postcodeReceiver.GetPostcodeData(selection.Postcode);
      var up = new List<BusStopsAndIncomingBuses>();
      
      try
      {
        var stops = tfLReceiver.GetBusStops(postcode.longitude, postcode.latitude);
        stops = sorter.sortByDistance(stops, postcode);

        for (var i = 0; i < 2; i++)
        {

          var stop = stops[i];
          var upcomingBuses = tfLReceiver.GetBusArrivals(stop.naptanId);
          var upcomingBusesSorted = sorter.sortByTime(upcomingBuses);
          up.Add(new BusStopsAndIncomingBuses(stop.naptanId, sorter.getFirstNBuses(upcomingBusesSorted, 5),
            stop.commonName));
        }
      }
      catch (NullReferenceException ex)
      {
        up.Add(new BusStopsAndIncomingBuses("Invalid Postcode", new List<Bus>(), "Error"));
      }
      
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

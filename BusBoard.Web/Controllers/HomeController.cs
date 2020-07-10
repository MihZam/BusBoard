using System;
using System.Collections.Generic;
using System.Globalization;
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
      // Add some properties to the BusInfo view model with the data you want to render on the page.
      // Write code here to populate the view model with info from the APIs.
      // Then modify the view (in Views/Home/BusInfo.cshtml) to render upcoming buses.
      var info = new BusInfo(selection.Postcode);
      return View(info);
    }
    
    public ActionResult BusStopInfo(PostcodeSelection selection)
    {
      var postcodeReceiver = new DataReceiverFromPostcodes();
      var tfLReceiver = new DataReceiverFromTfL();
      
      var postcode = postcodeReceiver.GetPostcodeData(selection.Postcode);
      var stops = tfLReceiver.GetBusStops(postcode.longitude, postcode.latitude);
      
      var info = new BusStopInfo(stops);
      return View(info);
    }
    
    public ActionResult BusStopTimingInfo(BusStopSelection selection)
    {
      var tfLReceiver = new DataReceiverFromTfL();
      var sorter = new Sorter();
      
      var upcomingBuses = tfLReceiver.GetBusArrivals(selection.BusStop);
      var upcomingBusesSorted = sorter.sortByTime(upcomingBuses);

      var info = new BusStopTimingInfo(upcomingBusesSorted);
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

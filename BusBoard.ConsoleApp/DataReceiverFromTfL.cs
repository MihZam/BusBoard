using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Web.Caching;

namespace BusBoard.ConsoleApp
{
    public class DataReceiverFromTfL
    {
        RestClient client = new RestClient("https://api.tfl.gov.uk/");

        public List<Bus> GetBusArrivals(string busStopCode)
        {
            RestRequest request = new RestRequest($"StopPoint/{busStopCode}/Arrivals", DataFormat.Json);
            var response = client.Get<List<Bus>>(request);
            return response.Data;
        }

        public List<BusStop> GetBusStops(string lon, string lat)
        {
            RestRequest request = new RestRequest(
                $"StopPoint?stopTypes=NaptanBusCoachStation%2C%20NaptanBusWayPoint%2C%20NaptanOnstreetBusCoachStopCluster%2C%20NaptanOnstreetBusCoachStopPair%2C%20NaptanPrivateBusCoachTram%2C%20NaptanPublicBusCoachTram&modes=bus&lat={lat}&lon={lon}",
                DataFormat.Json);
            var response = client.Get<PostcodeJson>(request);
            return response.Data.stopPoints;
        }
    }
}
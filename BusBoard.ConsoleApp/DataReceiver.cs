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
            var busList = response.Data;
            return busList;
        }
    }
}
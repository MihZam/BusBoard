using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Web.Caching;

namespace BusBoard.ConsoleApp
{
    public class DataReceiver
    {
        RestClient client = new RestClient("https://api.tfl.gov.uk/");

        public List<Bus> processRequest(string busStopCode)
        {
            RestRequest request = new RestRequest($"StopPoint/{busStopCode}/Arrivals", DataFormat.Json);
            var response = client.Get<List<Bus>>(request);
            var busList = response.Data;
            return busList;
        }
    }
}
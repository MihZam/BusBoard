using System.Collections.Generic;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    public class DataReceiverFromPostcodes
    {
        RestClient client = new RestClient("https://api.postcodes.io/postcodes/");

        public Postcode GetPostcodeData(string postcodeInput)
        {
            RestRequest request = new RestRequest(postcodeInput, DataFormat.Json);
            var response = client.Get<postcodeContainer>(request);
            return response.Data.result;
        }
    }
}
using System.Collections.Generic;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    public class DataReceiverFromPostCodes
    {
        RestClient client = new RestClient("https://api.postcodes.io/postcodes/");

        public PostCode GetPostCodeData(string postCodeInput)
        {
            RestRequest request = new RestRequest(postCodeInput, DataFormat.Json);
            var response = client.Get<random>(request);
            return response.Data.result;
        }
    }
}
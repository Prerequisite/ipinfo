using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ipinfo.Classes
{
    class ApiWorker
    {
        public async Task<bool> SendRequest(string ipAddress)
        {
            var apiUrl = "http://ipinfo.io/";
            var RequestUrl = String.Format("http://ipinfo.io/{0}/{1}", ipAddress, "json");


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);


            HttpResponseMessage responseMessage = new HttpResponseMessage();
            responseMessage = await client.GetAsync(RequestUrl);

            string content = await responseMessage.Content.ReadAsStringAsync();
            ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(content);

            Console.WriteLine("\r\n" + "Results" + "\r\n");
            Console.WriteLine("    IP......... : " + response.IP);
            Console.WriteLine("    Hostname... : " + response.Hostname);
            Console.WriteLine("    Country.... : " + response.Country);
            Console.WriteLine("    City....... : " + response.City);
            Console.WriteLine("    Postcode... : " + response.Postal);
            Console.WriteLine("    Lat - Long. : " + response.Loc);
            Console.WriteLine("    Organisation: " + response.Org);
            Console.WriteLine("\r\n");

            return true;
        }
    }
}



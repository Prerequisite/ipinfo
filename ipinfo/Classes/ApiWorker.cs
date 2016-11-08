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
        public async Task<ApiResponse> SendRequest(string ipAddress)
        {
            const string apiUrl = "http://ipinfo.io/";
            var requestUrl = String.Format("http://ipinfo.io/{0}/{1}", ipAddress, "json");

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(apiUrl)
            };

            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUrl);
                var content = await responseMessage.Content.ReadAsStringAsync();
                ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(content);


                Console.WriteLine("\r\n" + "Results" + "\r\n");
                Console.WriteLine("    IP . . . .  : " + response.IP);
                Console.WriteLine("    Hostname  . : " + (response.Hostname ?? "Unknown"));
                Console.WriteLine("    Country . . : " + (response.Country ?? "Unknown"));
                Console.WriteLine("    City  . . . : " + (response.City ?? "Unknown"));
                Console.WriteLine("    Postcode  . : " + (response.Postal ?? "Unknown"));
                Console.WriteLine("    Lat - Long  : " + (response.Loc ?? "Unknown"));
                Console.WriteLine("    Organisation: " + (response.Org ?? "Unknown"));

                return response;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();

                return null;
            }
        }
    }
}



using Ipinfo.Classes;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ipinfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            var isValid = Parser.Default.ParseArguments(args, options);

            if (isValid && args[1].IsIPv4())
            {
                var apiWorker = new ApiWorker();
                apiWorker.SendRequest(args[1]).Wait();
            }
            else
            {   
                Console.WriteLine("\r\n" + "Invalid arguments passed");
                Console.WriteLine("\r\n" + "Examples:" + "\r\n");
                Console.WriteLine("    > ipinfo -i 8.8.8.8  ... Geolocate an IP Address");
            }

        }
    }
}

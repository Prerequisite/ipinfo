using Ipinfo.Classes;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (isValid)
            {
                Request(args[1]);
            }
            Console.ReadLine();
        }

        public static async void Request(string ipAddress)
        {
            ApiWorker apiw = new ApiWorker();
            await apiw.SendRequest(ipAddress);
        }
    }
}

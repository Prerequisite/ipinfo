using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ipinfo.Classes
{
    class Options
    {
        [Option('i', "ipaddress", Required = true,
        HelpText = "IP Address to locate.")]
        public string IPAddress { get; set; }
    }
}

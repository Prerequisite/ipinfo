using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipinfo.Classes
{
    public static class Extensions 
    {
        /// <summary>
        /// Indicates if the string is an IPv4 address.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsIPv4(this String value)
        {
            var quads = value.Split('.');

            if (quads.Length != 4)
                return false;

            foreach (var quad in quads)
            {
                int q;
                if (!Int32.TryParse(quad, out q)
                    || !q.ToString().Length.Equals(quad.Length)
                    || q < 0
                    || q > 255)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

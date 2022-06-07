using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InfoPresenter
{
    public class MyData
    {
        public string ServiceData { get; set; }
        public string LocalData { get; set; }
        public static void Info()
        {
            Console.WriteLine(InfoString());
            Console.WriteLine();
        }

        public string Description { get {
                return InfoString();
            } 
            }

        public static string InfoString()
        {
            var date = DateTime.Now;
            string ret = date.ToString("yyyy/MM/dd HH:mm:ss") + "\n";
            ret += "Witold Frącek 254511\n";
            ret += Environment.UserName + "\n";
            ret += Environment.OSVersion + "\n";
            ret += Environment.Version + "\n";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ret += ip.ToString();
                    break;
                }
            }
            return ret;
        }

    }
}

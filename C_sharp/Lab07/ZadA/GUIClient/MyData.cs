using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InfoPresenter
{
    class MyData
    {
        public static void Info()
        {
            //var date = DateTime.Now;
            //Console.WriteLine(date.ToString("yyyy/MM/dd HH:mm:ss"));
            //Console.WriteLine("Witold Frącek 254511");
            //Console.WriteLine(Environment.UserName);
            //Console.WriteLine(Environment.OSVersion);
            //Console.WriteLine(Environment.Version);
            //var host = Dns.GetHostEntry(Dns.GetHostName());
            //foreach (var ip in host.AddressList)
            //{
            //    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            //    {
            //        Console.WriteLine(ip);
            //        break;
            //    }
            //}
            Console.WriteLine(InfoString());
            Console.WriteLine();
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

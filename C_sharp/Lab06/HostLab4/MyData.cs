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
            var date = DateTime.Now;
            Console.WriteLine(date.ToString("yyyy/MM/dd HH:mm:ss"));
            Console.WriteLine("Witold Frącek 254511");
            Console.WriteLine(Environment.UserName);
            Console.WriteLine(Environment.OSVersion);
            Console.WriteLine(Environment.Version);
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    Console.WriteLine(ip);
                    break;
                }
            }
            Console.WriteLine();
        }

    }
}

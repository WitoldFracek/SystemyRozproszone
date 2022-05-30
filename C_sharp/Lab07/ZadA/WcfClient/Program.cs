using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfoPresenter;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyData.Info();
            do
            {
                try
                {
                    Print("Podaj format (xml lub json)");
                    string format = Input().ToLower();
                    Print("Podaj metodę (GET, POST lub DELETE)");
                    string method = Input().ToUpper();
                    Print("Podaj URI:");
                    string uri = Input().ToLower();
                    HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;

                    req.KeepAlive = false;
                    req.Method = method;
                    if (format == "xml")
                    {
                        req.ContentType = "text/xml";
                    }
                    else if (format == "json")
                    {
                        req.ContentType = "application/json";
                    }
                    else
                    {
                        Print("Podałeś złe dane!");
                        continue;
                    }
                    switch (method)
                    {
                        case "GET":
                            break;
                        case "POST":
                            Print("Wklej zawartość (w jednej linii!)");
                            string data = Input();
                            byte[] bufor = Encoding.UTF8.GetBytes(data);
                            req.ContentLength = bufor.Length;
                            Stream postData = req.GetRequestStream();
                            postData.Write(bufor, 0, bufor.Length);
                            postData.Close();
                            break;
                        default:
                            break;
                    }
                    HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                    Encoding enc = Encoding.GetEncoding(1252);
                    StreamReader responseStream = new StreamReader(resp.GetResponseStream(), enc);
                    string responseString = responseStream.ReadToEnd();
                    responseStream.Close();
                    resp.Close();
                    Print(responseString);
                }
                catch (Exception e)
                {
                    Print(e.Message.ToString());
                }
                Print();
                Print("Do you want to continue? Y/n");
            } while (Console.ReadLine().ToUpper() == "Y");
        }

        static void Print(string message = "")
        {
            Console.WriteLine(message);
        }

        static string Input()
        {
            return Console.ReadLine();
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GUIClient
{
    public static class JsonConverter
    {
        public static string ConvertObject(this object obj)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            return ser.Serialize(obj);
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return ToStringWithPadding(30);
        }
        public string ToStringWithPadding(int padding)
        {
            string ret = "";
            foreach(var elem in new List<Object> { Id, Title, Author, Price })
            {
                ret += elem.ToString().PadRight(padding);
            }
            return ret;
        }

        public static Book FromStringWithPadding(string str)
        {
            var splitted = str.Split(' ');
            var clear = ClearString(splitted);
            return new Book
            {
                Id = int.Parse(clear[0]),
                Title = clear[1],
                Author = clear[2],
                Price = double.Parse(clear[3])
            };
        }

        private static string[] ClearString(string[] str)
        {
            string[] clear = { };
            foreach(string elem in str)
            {
                if(elem != "")
                {
                    clear.Append(elem);
                }
                Console.WriteLine(elem);
            }
            return clear;
        }
    }

    public class GuiClient
    {
        private static string bookHttpAddress = "http://localhost:54458/Shop.svc/json/books";
        private static string myDataHttpAddress = "http://localhost:54458/Shop.svc/json/MyData";
        private static Encoding encoding = Encoding.GetEncoding(1252);

        public static string GetMyData()
        {
            HttpWebRequest req = WebRequest.Create(myDataHttpAddress) as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            req.Method = "GET";

            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader responseStream = new StreamReader(res.GetResponseStream(), encoding);
            string responseString = responseStream.ReadToEnd();

            responseStream.Close();
            res.Close();

            dynamic responseJson = Newtonsoft.Json.JsonConvert.DeserializeObject(responseString);
            return responseJson["Data"];
        }

        private static string GetAllBooksJson()
        {
            HttpWebRequest req = WebRequest.Create(bookHttpAddress) as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            req.Method = "GET";

            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader responseStream = new StreamReader(res.GetResponseStream(), encoding);
            string responseString = responseStream.ReadToEnd();

            responseStream.Close();
            res.Close();
            return responseString;
        }

        public static List<Book> GetAllBooks()
        {
            string booksJson = GetAllBooksJson();
            List<Book> ret = new List<Book>();
            var dt = JsonConvert.DeserializeObject<DataTable>(booksJson);
            foreach(DataRow row in dt.Rows)
            {
                ret.Add(new Book
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Title = row.ItemArray[1].ToString(),
                    Author = row.ItemArray[2].ToString(),
                    Price = double.Parse(row.ItemArray[3].ToString())
                });
            }
            return ret;
        }

        public static string DeleteBook(int id)
        {
            HttpWebRequest req = WebRequest.Create($"{bookHttpAddress}/{id}") as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            req.Method = "DELETE";

            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader responseStream = new StreamReader(res.GetResponseStream(), encoding);
            string responseString = responseStream.ReadToEnd();

            responseStream.Close();
            res.Close();
            return responseString;
        }

        public static string AddBook(Book book)
        {
            string bookJson = JsonConverter.ConvertObject(book);
            HttpWebRequest req = WebRequest.Create($"{bookHttpAddress}") as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            req.Method = "POST";

            byte[] buffer = Encoding.UTF8.GetBytes(bookJson);
            req.ContentLength = buffer.Length;
            Stream posData = req.GetRequestStream();
            posData.Write(buffer, 0, buffer.Length);
            posData.Close();

            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader responseStream = new StreamReader(res.GetResponseStream(), encoding);
            string responseString = responseStream.ReadToEnd();

            responseStream.Close();
            res.Close();
            return responseString;
        }

        public static string ModifyBook(Book book)
        {
            string bookJson = JsonConverter.ConvertObject(book);
            HttpWebRequest req = WebRequest.Create($"{bookHttpAddress}") as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            req.Method = "PUT";

            byte[] buffer = Encoding.UTF8.GetBytes(bookJson);
            req.ContentLength = buffer.Length;
            Stream posData = req.GetRequestStream();
            posData.Write(buffer, 0, buffer.Length);
            posData.Close();

            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader responseStream = new StreamReader(res.GetResponseStream(), encoding);
            string responseString = responseStream.ReadToEnd();

            responseStream.Close();
            res.Close();
            return responseString;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebClientMVC.Models;

namespace WebClientMVC
{

    public static class JsonParser
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }

    public class Client
    {
        private static string booksHttp = "https://localhost:44375/Service1.svc/json/books";
        private static string myDataHttp = "https://localhost:44375/Service1.svc/MyData";
        private static Encoding encoding = Encoding.GetEncoding(1252);

        public static string GetMyData()
        {
            HttpWebRequest req = WebRequest.Create(myDataHttp) as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader resStream = new StreamReader(res.GetResponseStream(), encoding);
            string responseString = resStream.ReadToEnd();
            resStream.Close();
            res.Close();

            dynamic myData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseString);
            return myData["Description"];
        }

        private static string GetAllBooksJson()
        {
            HttpWebRequest req = WebRequest.Create(booksHttp) as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream(), encoding);
            string response = reader.ReadToEnd();
            reader.Close();
            res.Close();
            return response;
        }

        public static List<Book> GetBooks()
        {
            var bookList = new List<Book>();
            var inputJson = GetAllBooksJson();
            var dt = JsonConvert.DeserializeObject<DataTable>(inputJson);

            foreach (DataRow dataRow in dt.Rows)
            {

                var Id = int.Parse(dataRow.ItemArray[0].ToString());
                var Title = dataRow.ItemArray[1].ToString();
                var Author = dataRow.ItemArray[2].ToString();
                var Price = int.Parse(dataRow.ItemArray[3].ToString());
                var bookItem = new Book(Id, Title, Author, Price);

                bookList.Add(bookItem);
            }
            return bookList;
        }

        public static string AddNewBook(Book book)
        {
            string jsonBook = JsonParser.ToJson(book);
            HttpWebRequest req = WebRequest.Create(booksHttp) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "POST";
            req.ContentType = "application/json";

            byte[] bufor = Encoding.UTF8.GetBytes(jsonBook);
            req.ContentLength = bufor.Length;
            Stream postData = req.GetRequestStream();
            postData.Write(bufor, 0, bufor.Length);
            postData.Close();

            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            StreamReader responseStream = new StreamReader(res.GetResponseStream(), encoding);
            string responseString = responseStream.ReadToEnd();
            responseStream.Close();
            res.Close();
            return responseString;
        }

        public static string DeleteBook(int id)
        {
            HttpWebRequest req = WebRequest.Create(booksHttp + "/" + id) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "DELETE";
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            StreamReader responseStream = new StreamReader(resp.GetResponseStream(), encoding);
            string responseString = responseStream.ReadToEnd();
            responseStream.Close();
            resp.Close();
            return responseString;
        }

        public static string ModifyBook(Book book)
        {
            string bookJson = JsonParser.ToJson(book);
            HttpWebRequest req = WebRequest.Create(booksHttp) as HttpWebRequest;
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

        public static string GetNextBook(int id)
        {
            HttpWebRequest req = WebRequest.Create(booksHttp + "/next/" + id) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "GET";
            req.ContentType = "application/json";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            //przekodowanie tekstu odpowiedzi: 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            StreamReader responseStream = new StreamReader(resp.GetResponseStream(), encoding);
            string responseString = responseStream.ReadToEnd();
            responseStream.Close();
            resp.Close();
            return responseString;
        }
    }
}

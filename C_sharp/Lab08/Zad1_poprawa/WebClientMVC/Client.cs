using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        private static string booksHttp = "http://localhost:49424/Service1.svc/json/books";
        private static string moviesHttp = "http://localhost:49424/Service1.svc/json/movies";
        private static string catsHttp = "http://localhost:49424/Service1.svc/json/cats";
        private static string myDataHttp = "http://localhost:49424/Service1.svc/MyData";
        private static Encoding encoding = Encoding.GetEncoding(1252);

        public static string GetMyData()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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

        //BOOKS

        private static string GetAllBooksJson()
        {
            Debug.WriteLine("Before Request");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HttpWebRequest req = WebRequest.Create(booksHttp) as HttpWebRequest;
            Debug.WriteLine("Post Request");
            req.KeepAlive = false;
            req.ContentType = "application/json";
            Debug.WriteLine("Before response");
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            Debug.WriteLine("Post response");
            StreamReader reader = new StreamReader(res.GetResponseStream(), encoding);
            string response = reader.ReadToEnd();
            reader.Close();
            res.Close();
            Debug.WriteLine(response);
            return response;
        }

        public static List<Book> GetBooks()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Debug.WriteLine("GEtBooks");
            var bookList = new List<Book>();
            string inputJson = GetAllBooksJson();
            Console.WriteLine("GetAllBooks");
            var dt = JsonConvert.DeserializeObject<DataTable>(inputJson);

            foreach (DataRow dataRow in dt.Rows)
            {

                var Id = int.Parse(dataRow.ItemArray[0].ToString());
                var Title = dataRow.ItemArray[1].ToString();
                var Author = dataRow.ItemArray[2].ToString();
                var Price = double.Parse(dataRow.ItemArray[3].ToString());
                var bookItem = new Book(Id, Title, Author, Price);

                bookList.Add(bookItem);
            }
            return bookList;
        }

        public static string AddNewBook(Book book)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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

        //MOVIES

        private static string GetAllMoviesJson()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HttpWebRequest req = WebRequest.Create(moviesHttp) as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream(), encoding);
            string response = reader.ReadToEnd();
            reader.Close();
            res.Close();
            return response;
        }

        public static List<Movie> GetMovies()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Debug.WriteLine("GETMovies");
            var movieList = new List<Movie>();
            string inputJson = GetAllMoviesJson();
            Console.WriteLine("GetAllMovies");
            var dt = JsonConvert.DeserializeObject<DataTable>(inputJson);

            foreach (DataRow dataRow in dt.Rows)
            {

                var Id = int.Parse(dataRow.ItemArray[0].ToString());
                var Title = dataRow.ItemArray[1].ToString();
                var Director = dataRow.ItemArray[2].ToString();
                var Length = double.Parse(dataRow.ItemArray[3].ToString());
                var movieItem = new Movie(Id, Title, Director, Length);

                movieList.Add(movieItem);
            }
            return movieList;
        }

        public static string AddNewMovie(Movie movie)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string jsonMovie = JsonParser.ToJson(movie);
            HttpWebRequest req = WebRequest.Create(moviesHttp) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "POST";
            req.ContentType = "application/json";

            byte[] bufor = Encoding.UTF8.GetBytes(jsonMovie);
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

        public static string DeleteMovie(int id)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HttpWebRequest req = WebRequest.Create(moviesHttp + "/" + id) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "DELETE";
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            StreamReader responseStream = new StreamReader(resp.GetResponseStream(), encoding);
            string responseString = responseStream.ReadToEnd();
            responseStream.Close();
            resp.Close();
            return responseString;
        }

        public static string ModifyMovie(Movie movie)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string movieJson = JsonParser.ToJson(movie);
            HttpWebRequest req = WebRequest.Create(moviesHttp) as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            req.Method = "PUT";

            byte[] buffer = Encoding.UTF8.GetBytes(movieJson);
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

        public static string GetNextMovie(int id)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HttpWebRequest req = WebRequest.Create(moviesHttp + "/next/" + id) as HttpWebRequest;
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

        //CATS

        private static string GetAllCatsJson()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HttpWebRequest req = WebRequest.Create(catsHttp) as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream(), encoding);
            string response = reader.ReadToEnd();
            reader.Close();
            res.Close();
            return response;
        }

        public static List<Cat> GetCats()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var catList = new List<Cat>();
            string inputJson = GetAllCatsJson();
            var dt = JsonConvert.DeserializeObject<DataTable>(inputJson);

            foreach (DataRow dataRow in dt.Rows)
            {

                var Id = int.Parse(dataRow.ItemArray[0].ToString());
                var Name = dataRow.ItemArray[1].ToString();
                var Breed = dataRow.ItemArray[2].ToString();
                var Age = int.Parse(dataRow.ItemArray[3].ToString());
                var Sex = dataRow.ItemArray[4].ToString().ToCharArray()[0];
                var catItem = new Cat(Id, Name, Breed, Age, Sex);

                catList.Add(catItem);
            }
            return catList;
        }

        public static string AddNewCat(Cat cat)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string jsonCat = JsonParser.ToJson(cat);
            HttpWebRequest req = WebRequest.Create(catsHttp) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "POST";
            req.ContentType = "application/json";

            byte[] bufor = Encoding.UTF8.GetBytes(jsonCat);
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

        public static string DeleteCat(int id)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HttpWebRequest req = WebRequest.Create(catsHttp + "/" + id) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "DELETE";
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            StreamReader responseStream = new StreamReader(resp.GetResponseStream(), encoding);
            string responseString = responseStream.ReadToEnd();
            responseStream.Close();
            resp.Close();
            return responseString;
        }

        public static string ModifyCat(Cat cat)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string catJson = JsonParser.ToJson(cat);
            HttpWebRequest req = WebRequest.Create(catsHttp) as HttpWebRequest;
            req.KeepAlive = false;
            req.ContentType = "application/json";
            req.Method = "PUT";

            byte[] buffer = Encoding.UTF8.GetBytes(catJson);
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

        public static string GetNextCat(int id)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            HttpWebRequest req = WebRequest.Create(catsHttp + "/next/" + id) as HttpWebRequest;
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

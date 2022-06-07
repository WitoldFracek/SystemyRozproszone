using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // --- BOOKS --------------------------------------------------------------------------
        [OperationContract]
        [WebGet(UriTemplate = "/books", ResponseFormat = WebMessageFormat.Xml)]
        List<Book> GetAllBooksXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/books", ResponseFormat = WebMessageFormat.Json)]
        List<Book> GetAllBooksJson();

        [OperationContract]
        [WebGet(UriTemplate = "/books/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Book GetBookXml(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/books/{id}", ResponseFormat = WebMessageFormat.Json)]
        Book GetBookJson(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/books/next/{id}", ResponseFormat = WebMessageFormat.Json)]
        Book GetNextBookJson(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books", Method = "POST", RequestFormat = WebMessageFormat.Xml)]
        string AddBookXml(Book book);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        string AddBookJson(Book book);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books/{id}", Method = "DELETE", RequestFormat = WebMessageFormat.Xml)]
        string DeleteBookXml(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books/{id}", Method = "DELETE", RequestFormat = WebMessageFormat.Json)]
        string DeleteBookJson(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/MyData", ResponseFormat = WebMessageFormat.Json)]
        DataDescription GetMyData();

        [OperationContract]
        [WebInvoke(UriTemplate = "/books", Method = "PUT", RequestFormat = WebMessageFormat.Xml)]
        string ModifyBookXml(Book book);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
        string ModifyBookJson(Book book);

        // --- MOVIES -----------------------------------------------------------------------------------------
        [OperationContract]
        [WebGet(UriTemplate = "/movies", ResponseFormat = WebMessageFormat.Xml)]
        List<Movie> GetAllMoviesXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/movies", ResponseFormat = WebMessageFormat.Json)]
        List<Movie> GetAllMoviesJson();

        [OperationContract]
        [WebGet(UriTemplate = "/movies/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Movie GetMovieXml(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/movies/{id}", ResponseFormat = WebMessageFormat.Json)]
        Movie GetMovieJson(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/movies/next/{id}", ResponseFormat = WebMessageFormat.Json)]
        Movie GetNextMovieJson(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/movies", Method = "POST", RequestFormat = WebMessageFormat.Xml)]
        string AddMovieXml(Movie movie);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/movies", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        string AddMovieJson(Movie movie);

        [OperationContract]
        [WebInvoke(UriTemplate = "/movies/{id}", Method = "DELETE", RequestFormat = WebMessageFormat.Xml)]
        string DeleteMovieXml(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/movies/{id}", Method = "DELETE", RequestFormat = WebMessageFormat.Json)]
        string DeleteMovieJson(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/movies", Method = "PUT", RequestFormat = WebMessageFormat.Xml)]
        string ModifyMovieXml(Movie movie);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/movies", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
        string ModifyMovieJson(Movie movie);

        // --- CAT -----------------------------------------------------------------------------------------------
        [OperationContract]
        [WebGet(UriTemplate = "/cats", ResponseFormat = WebMessageFormat.Xml)]
        List<Cat> GetAllCatsXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/cats", ResponseFormat = WebMessageFormat.Json)]
        List<Cat> GetAllCatsJson();

        [OperationContract]
        [WebGet(UriTemplate = "/cats/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Cat GetCatXml(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/cats/{id}", ResponseFormat = WebMessageFormat.Json)]
        Cat GetCatJson(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/cats/next/{id}", ResponseFormat = WebMessageFormat.Json)]
        Cat GetNextCatJson(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/cats", Method = "POST", RequestFormat = WebMessageFormat.Xml)]
        string AddCatXml(Cat cat);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/cats", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        string AddCatJson(Cat cat);

        [OperationContract]
        [WebInvoke(UriTemplate = "/cats/{id}", Method = "DELETE", RequestFormat = WebMessageFormat.Xml)]
        string DeleteCatXml(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/cats/{id}", Method = "DELETE", RequestFormat = WebMessageFormat.Json)]
        string DeleteCatJson(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/cats", Method = "PUT", RequestFormat = WebMessageFormat.Xml)]
        string ModifyCatXml(Cat cat);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/cats", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
        string ModifyCatJson(Cat cat);

    }

    [DataContract]
    public class Book
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string Title { get; set; }

        [DataMember(Order = 2)]
        public string Author { get; set; }

        [DataMember(Order = 3)]
        public double Price { get; set; }
    }

    [DataContract]
    public class Movie
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string Title { get; set; }

        [DataMember(Order = 2)]
        public string Director { get; set; }

        [DataMember(Order = 3)]
        public double Length { get; set; }

    }

    [DataContract]
    public class Cat
    {
        [DataMember(Order = 0)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 2)]
        public string Breed { get; set; }

        [DataMember(Order = 3)]
        public int Age { get; set; }

        [DataMember(Order = 4)]
        public char Sex { get; set; }
    }

    [DataContract]
    public class DataDescription
    {
        [DataMember(Order = 0)]
        public string Description { get; set; }
    }
}

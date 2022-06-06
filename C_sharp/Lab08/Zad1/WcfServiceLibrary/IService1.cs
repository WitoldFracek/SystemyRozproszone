using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
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
        [WebGet(UriTemplate = "/json'books/next/{id}", ResponseFormat = WebMessageFormat.Json)]
        Book GetNextBookJson(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books", Method = "POST", ResponseFormat = WebMessageFormat.Xml)]
        string AddBookXml(Book book);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        string AddBookJson(Book book);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Xml)]
        string DeleteBookXml(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        string DeleteBookJson(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/MyData", ResponseFormat = WebMessageFormat.Json)]
        DataDescription GetMyData();
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
        public int Length { get; set; }

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
    }

    [DataContract]
    public class DataDescription
    {
        [DataMember(Order = 0)]
        public string Description { get; set; }
    }
}

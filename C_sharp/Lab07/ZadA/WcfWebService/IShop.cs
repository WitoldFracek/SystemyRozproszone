using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfWebService
{
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
    public class MyDataPackage
    {
        [DataMember(Order = 0)]
        public string Data
        {
            get
            {
                return InfoPresenter.MyData.InfoString();
            }
            set
            {

            }
        }
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IShop
    {

        [OperationContract]
        [WebGet(UriTemplate = "/books")]
        List<Book> GetAllXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/books", ResponseFormat = WebMessageFormat.Json)]
        List<Book> GetAllJson();

        [OperationContract]
        [WebGet(UriTemplate = "/books/{id}", ResponseFormat = WebMessageFormat.Xml)]
        Book GetByIdXml(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/books/{id}", ResponseFormat = WebMessageFormat.Json)]
        Book GetByIdJson(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books", Method = "POST", RequestFormat = WebMessageFormat.Xml)]
        string AddXml(Book book);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books", Method = "POST", RequestFormat = WebMessageFormat.Json)]
        string AddJson(Book book);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books/{id}", Method = "DELETE", RequestFormat = WebMessageFormat.Xml)]
        string DeleteXml(string id);
        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books/{id}", Method = "DELETE", RequestFormat = WebMessageFormat.Json)]
        string DeleteJson(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books", Method = "PUT", RequestFormat = WebMessageFormat.Xml)]
        string ModifyXml(Book book);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books", Method = "PUT", RequestFormat = WebMessageFormat.Json)]
        string ModifyJson(Book book);

        [OperationContract]
        [WebGet(UriTemplate = "/MyData", ResponseFormat = WebMessageFormat.Xml)]
        MyDataPackage GetMyDataXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/MyData", ResponseFormat = WebMessageFormat.Json)]
        MyDataPackage GetMyDataJson();
    }
}

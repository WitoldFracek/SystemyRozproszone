using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;

namespace WcfWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Shop : IShop
    {
        private static List<Book> dataset = new List<Book>()
        {
            new Book{ Id = 0, Title = "Bieguni", Author = "Olga Tokarczuk", Price = 20.34 },
            new Book{ Id = 1, Title = "Black Out", Author = "Marc Elsberg", Price = 35.00 },
            new Book{ Id = 2, Title = "Wiedźmin", Author = "Andrzej Sapkowski", Price = 32.05 }
        };

        public string AddJson(Book book)
        {
            return AddXml(book);
        }

        public string AddXml(Book book)
        {
            if (book == null)
            {
                throw new WebFaultException<string>("400: Bad request", HttpStatusCode.BadRequest);
            }
            if(-1 != dataset.FindIndex(b => b.Title.ToLower() == book.Title.ToLower()
            && b.Author.ToLower() == book.Author.ToLower()))
            {
                throw new WebFaultException<string>("409: Book already exists", HttpStatusCode.Conflict);
            }
            int newId = dataset.Max(b => b.Id) + 1;
            book.Id = newId;
            dataset.Add(book);
            return $"Added item with id = {book.Id}";
        }

        public string DeleteJson(string id)
        {
            return DeleteXml(id);
        }

        public string DeleteXml(string id)
        {
            int identifier = int.Parse(id);
            int index = dataset.FindIndex(b => b.Id == identifier);
            if (index == -1)
            {
                throw new WebFaultException<string>("404: Not found", HttpStatusCode.NotFound);
            }
            var deleted = dataset[index];
            dataset.RemoveAt(index);
            return $"Removed item with id = {deleted.Id}";
        }

        public List<Book> GetAllJson()
        {
            return GetAllXml();
        }

        public List<Book> GetAllXml()
        {
            return dataset;
        }

        public Book GetByIdJson(string id)
        {
            return GetByIdXml(id);
        }

        public Book GetByIdXml(string id)
        {
            int identifier = int.Parse(id);
            int index = dataset.FindIndex(b => b.Id == identifier);
            if (index == -1)
            {
                throw new WebFaultException<string>("404: Not Found", HttpStatusCode.NotFound);
            }
            return dataset[index];
        }
    }
}

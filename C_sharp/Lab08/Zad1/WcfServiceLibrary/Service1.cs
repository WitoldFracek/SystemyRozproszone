using InfoPresenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
namespace WcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        private static List<Book> _books = new List<Book>()
        {
            new Book { Id = 0, Title = "Pani jeziora", Author = "Andrzej Sapkowski", Price = 34.5 },
            new Book { Id = 1, Title = "Bieguni", Author = "Olga Tokarczuk", Price = 40.7 },
            new Book { Id = 2, Title = "Helisa", Author = "Marc Elsberg", Price = 50.2 }
        };
        public string AddBookJson(Book book)
        {
            return AddBookXml(book);
        }

        public string AddBookXml(Book book)
        {
            if (book == null)
            {
                throw new WebFaultException<string>("400: Bad Request", System.Net.HttpStatusCode.BadRequest);
            }
            int unusedIndex = _books.Max(b => b.Id) + 1;
            _books.Add(book);
            return $"Added book. Id = {unusedIndex}";
        }

        public string DeleteBookJson(string id)
        {
            return DeleteBookXml(id);
        }

        public string DeleteBookXml(string id)
        {
            if(id == null)
            {
                return "Invalid book id";
            }

            int newId = 0;
            if (!int.TryParse(id, out newId))
            {
                return "Invalid book id";
            }
            int removeIndex = _books.FindIndex(b => b.Id == newId);
            if(removeIndex == -1)
            {
                return $"No book with id {newId}";
            }
            int removeId = _books[removeIndex].Id;
            _books.RemoveAt(removeIndex);
            return $"Removed book with id {removeId}";
        }

        public List<Book> GetAllBooksJson()
        {
            return GetAllBooksXml();
        }

        public List<Book> GetAllBooksXml()
        {
            return _books;
        }

        public Book GetBookJson(string id)
        {
             return GetBookXml(id);
        }

        public Book GetBookXml(string id)
        {
            int intId = int.Parse(id);
            int idx = _books.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return null;
            return _books.ElementAt(idx);
        }

        public DataDescription GetMyData()
        {
            string data = MyData.InfoString();
            return new DataDescription { Description = data  };
        }

        public Book GetNextBookJson(string id)
        {
            int intId = int.Parse(id);
            int idx = _books.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return null;
            idx = (idx + 1) % _books.Count();
            return _books.ElementAt(idx);
        }
    }
}

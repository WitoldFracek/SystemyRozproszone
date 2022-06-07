using InfoPresenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {

        private static List<Book> _books = new List<Book>()
        {
            new Book { Id = 0, Title = "Pani jeziora", Author = "Andrzej Sapkowski", Price = 34.5 },
            new Book { Id = 1, Title = "Bieguni", Author = "Olga Tokarczuk", Price = 40.7 },
            new Book { Id = 2, Title = "Helisa", Author = "Marc Elsberg", Price = 50.2 },
            new Book {Id = 3, Title = "Miecz przeznaczenia", Author = "Andrzej Sapkowski", Price = 30.0 }
        };

        private static List<Movie> _movies = new List<Movie>()
        {
            new Movie { Id = 0, Title = "Nowa nadzieja", Director = "Geoge Lucas", Length = 134.5 },
            new Movie { Id = 1, Title = "Titanic", Director = "James Cameron", Length = 140.7 },
            new Movie { Id = 2, Title = "Fortepian", Director = "Jane Campion", Length = 150.2 },
            new Movie { Id = 3, Title = "Jojo Rabbit", Director = "Taika Waititi", Length = 130.0 }
        };

        private static List<Cat> _cats = new List<Cat>()
        {
            new Cat { Id = 0, Name = "Neo", Breed = "British shorthair", Age = 5, Sex = 'M' },
            new Cat { Id = 1, Name = "Puszek", Breed = "Dachowiec", Age = 7, Sex = 'M' },
            new Cat { Id = 2, Name = "Kicia", Breed = "Maincoon", Age = 2, Sex = 'F' },
            new Cat { Id = 3, Name = "Ruzia", Breed = "Ragdoll", Age = 4, Sex = 'F' }
        };

        public string AddBookJson(Book book)
        {
            return AddBookXml(book);
        }

        public string AddBookXml(Book book)
        {
            if (book == null)
            {
                return "400: Bad Request. Book does not exist."; ;
            }
            int unusedIndex = _books.Max(b => b.Id) + 1;
            book.Id = unusedIndex;
            _books.Add(book);
            return $"Added book. Id = {unusedIndex}";
        }

        public string DeleteBookJson(string id)
        {
            return DeleteBookXml(id);
        }

        public string DeleteBookXml(string id)
        {
            if (id == null)
            {
                return "Invalid book id";
            }

            int newId = 0;
            if (!int.TryParse(id, out newId))
            {
                return "Invalid book id";
            }
            int removeIndex = _books.FindIndex(b => b.Id == newId);
            if (removeIndex == -1)
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

        public string ModifyBookXml(Book book)
        {
            int index = _books.FindIndex(b => b.Id == book.Id);
            if (index == -1)
            {
                return $"404: Not found";
            }
            _books[index] = book;
            return "Book modified";
        }

        public string ModifyBookJson(Book book)
        {
            return ModifyBookXml(book);
        }


        public DataDescription GetMyData()
        {
            string data = MyData.InfoString();
            return new DataDescription { Description = data };
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

        public string AddCatJson(Cat cat)
        {
            return AddCatXml(cat);
        }

        public string AddCatXml(Cat cat)
        {
            if (cat == null)
            {
                return "400: Bad Request. Cat does not exist."; ;
            }
            int unusedIndex = _cats.Max(c => c.Id) + 1;
            cat.Id = unusedIndex;
            _cats.Add(cat);
            return $"Added cat. Id = {unusedIndex}";
        }

        public string DeleteCatJson(string id)
        {
            return DeleteCatXml(id);
        }

        public string DeleteCatXml(string id)
        {
            if (id == null)
            {
                return "Invalid cat id";
            }

            int newId = 0;
            if (!int.TryParse(id, out newId))
            {
                return "Invalid cat id";
            }
            int removeIndex = _cats.FindIndex(c => c.Id == newId);
            if (removeIndex == -1)
            {
                return $"No cat with id {newId}";
            }
            int removeId = _cats[removeIndex].Id;
            _cats.RemoveAt(removeIndex);
            return $"Removed cat with id {removeId}";
        }

        public List<Cat> GetAllCatsJson()
        {
            return GetAllCatsXml();
        }

        public List<Cat> GetAllCatsXml()
        {
            return _cats;
        }

        public Cat GetCatJson(string id)
        {
            return GetCatXml(id);
        }

        public Cat GetCatXml(string id)
        {
            int intId = int.Parse(id);
            int idx = _cats.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return null;
            return _cats.ElementAt(idx);
        }

        public string ModifyCatXml(Cat cat)
        {
            int index = _cats.FindIndex(c => c.Id == cat.Id);
            if (index == -1)
            {
                return $"404: Not found";
            }
            _cats[index] = cat;
            return "Cat modified";
        }

        public string ModifyCatJson(Cat cat)
        {
            return ModifyCatXml(cat);
        }

        public Cat GetNextCatJson(string id)
        {
            int intId = int.Parse(id);
            int idx = _cats.FindIndex(b => b.Id == intId);
            if (idx == -1)
                return null;
            idx = (idx + 1) % _cats.Count();
            return _cats.ElementAt(idx);
        }

        public string AddMovieJson(Movie movie)
        {
            return AddMovieXml(movie);
        }

        public string AddMovieXml(Movie movie)
        {
            if (movie == null)
            {
                return "400: Bad Request. Cat does not exist."; ;
            }
            int unusedIndex = _movies.Max(m => m.Id) + 1;
            movie.Id = unusedIndex;
            _movies.Add(movie);
            return $"Added cat. Id = {unusedIndex}";
        }

        public string DeleteMovieJson(string id)
        {
            return DeleteMovieXml(id);
        }

        public string DeleteMovieXml(string id)
        {
            if (id == null)
            {
                return "Invalid movie id";
            }

            int newId = 0;
            if (!int.TryParse(id, out newId))
            {
                return "Invalid movie id";
            }
            int removeIndex = _movies.FindIndex(m => m.Id == newId);
            if (removeIndex == -1)
            {
                return $"No mvie with id {newId}";
            }
            int removeId = _movies[removeIndex].Id;
            _movies.RemoveAt(removeIndex);
            return $"Removed movie with id {removeId}";
        }

        public List<Movie> GetAllMoviesJson()
        {
            return GetAllMoviesXml();
        }

        public List<Movie> GetAllMoviesXml()
        {
            return _movies;
        }

        public Movie GetMovieJson(string id)
        {
            return GetMovieXml(id);
        }

        public Movie GetMovieXml(string id)
        {
            int intId = int.Parse(id);
            int idx = _movies.FindIndex(m => m.Id == intId);
            if (idx == -1)
                return null;
            return _movies.ElementAt(idx);
        }

        public string ModifyMovieXml(Movie movie)
        {
            int index = _movies.FindIndex(m => m.Id == movie.Id);
            if (index == -1)
            {
                return $"404: Not found";
            }
            _movies[index] = movie;
            return "Movie modified";
        }

        public string ModifyMovieJson(Movie movie)
        {
            return ModifyMovieXml(movie);
        }

        public Movie GetNextMovieJson(string id)
        {
            int intId = int.Parse(id);
            int idx = _movies.FindIndex(m => m.Id == intId);
            if (idx == -1)
                return null;
            idx = (idx + 1) % _movies.Count();
            return _movies.ElementAt(idx);
        }
    }
}

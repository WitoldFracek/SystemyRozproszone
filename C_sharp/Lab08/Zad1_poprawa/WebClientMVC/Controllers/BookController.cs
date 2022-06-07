using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebClientMVC.Models;

namespace WebClientMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }
        // GET: BookController
        public IActionResult Index()
        {
            List<Book> allBooks = new List<Book>();
            Debug.WriteLine("na poczatku Index");
            try
            {
                Debug.WriteLine("Index try");
                allBooks = Client.GetBooks();
                return View(allBooks);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return View("NoRunning");
            }
        }

        // GET: BookController/Details/5
        public IActionResult Details(int id)
        {
            List<Book> allBooks = Client.GetBooks();
            var book = allBooks.Where(b => b.Id == id).FirstOrDefault();
            return View(book);
        }

        // GET: BookController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Author,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = 0;
                try
                {
                    Client.AddNewBook(book);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View("NoRunning");
                }
            }
            return View(book);
        }

        // GET: BookController/Edit/5
        public IActionResult Edit(int? id)
        {
            List<Book> allBooks = Client.GetBooks();
            var book = allBooks.Where(b => b.Id == id).FirstOrDefault();
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Author,Price")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Client.ModifyBook(book);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View("NoRunning");
                }
            }
            return View(book);
        }

        // GET: BookController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<Book> allBooks = Client.GetBooks();
            var book = allBooks.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            List<Book> allBooks = Client.GetBooks();
            var book = allBooks.Where(b => b.Id == id).FirstOrDefault();
            try
            {
                Client.DeleteCat(book.Id);
            }
            catch (Exception ex)
            {
                return View("NoRunning");
            }
            return RedirectToAction(nameof(Index));
        }

        public string Next(int id)
        {
            return Client.GetNextBook(id);
        }

        public IActionResult TotalCost()
        {
            List<Book> allBooks = Client.GetBooks();
            return View(allBooks);
        }
    }
}

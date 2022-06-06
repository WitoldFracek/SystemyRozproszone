using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClientMVC.Models;

namespace WebClientMVC.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> allBooks = new List<Book>();
        // GET: BookController
        public ActionResult Index()
        {
            try
            {
                allBooks = Client.GetBooks();
                return View(allBooks);
            }
            catch (Exception ex)
            {
                return View("NoRunning");
            }
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = allBooks.Where(b => b.Id == id).FirstOrDefault();
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Title,Author,Price")] Book book)
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
        public ActionResult Edit(int id)
        {
            var book = allBooks.Where(b => b.Id == id).FirstOrDefault();
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Title,Author,Price")] Book book)
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
        public ActionResult Delete(int id)
        {
            var book = allBooks.Where(b => b.Id == id).FirstOrDefault();
            try
            {
                Client.DeleteBook(book.Id);
            }
            catch (Exception ex)
            {
                return View("NoRunning");
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public string Next(int id)
        {
            return Client.GetNextBook(id);
        }
    }
}

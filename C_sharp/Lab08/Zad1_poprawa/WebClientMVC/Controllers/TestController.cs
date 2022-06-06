using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClientMVC.Models;

namespace WebClientMVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            List<Book> allBooks = new List<Book>();
            Console.WriteLine("na poczatku Index");
            try
            {
                Console.WriteLine("Index try");
                allBooks = Client.GetBooks();
                return View(allBooks);
            }
            catch (Exception ex)
            {
                return View("NoRunning");
            }
        }
    }
}

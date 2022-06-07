using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClientMVC.Models;

namespace WebClientMVC.Controllers
{
    public class CatController : Controller
    {
        private readonly ILogger<CatController> _logger;
        public CatController(ILogger<CatController> logger)
        {
            _logger = logger;
        }
        // GET: BookController
        public IActionResult Index()
        {
            List<Cat> allCats = new List<Cat>();
            try
            {
                allCats = Client.GetCats();
                return View(allCats);
            }
            catch (Exception ex)
            {
                return View("NoRunning");
            }
        }

        // GET: BookController/Details/5
        public IActionResult Details(int? id)
        {
            List<Cat> allCats = Client.GetCats();
            var cat = allCats.Where(b => b.Id == id).FirstOrDefault();
            return View(cat);
        }

        // GET: BookController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Breed,Age,Sex")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                cat.Id = 0;
                try
                {
                    Client.AddNewCat(cat);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View("NoRunning");
                }
            }
            return View(cat);
        }

        // GET: BookController/Edit/5
        public IActionResult Edit(int? id)
        {
            List<Cat> allCats = Client.GetCats();
            var cat = allCats.Where(c => c.Id == id).FirstOrDefault();
            return View(cat);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Breed,Age,Sex")] Cat cat)
        {
            if (id != cat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Client.ModifyCat(cat);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View("NoRunning");
                }
            }
            return View(cat);
        }

        // GET: BookController/Delete/5
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            List<Cat> allCats = Client.GetCats();
            var cat = allCats.FirstOrDefault(c => c.Id == id);
            if(cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // POST: BookController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            List<Cat> allCats = Client.GetCats();
            var cat = allCats.Where(c => c.Id == id).FirstOrDefault();
            try
            {
                Client.DeleteCat(cat.Id);
            }
            catch (Exception ex)
            {
                return View("NoRunning");
            }
            return RedirectToAction(nameof(Index));
        }

        public string Next(int id)
        {
            return Client.GetNextCat(id);
        }
    }
}

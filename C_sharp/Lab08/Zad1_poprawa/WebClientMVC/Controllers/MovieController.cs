using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClientMVC.Models;

namespace WebClientMVC.Controllers
{
    public class MovieController : Controller
    {
        // GET: MovieController
        public ActionResult Index()
        {
            List<Movie> allMovies = new List<Movie>();
            try
            {
                allMovies = Client.GetMovies();
                return View(allMovies);
            }
            catch (Exception ex)
            {
                return View("NoRunning");
            }
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            List<Movie> allMovies = Client.GetMovies();
            var movie = allMovies.Where(m => m.Id == id).FirstOrDefault();
            return View(movie);
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Title,Director,Length")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.Id = 0;
                try
                {
                    Client.AddNewMovie(movie);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View("NoRunning");
                }
            }
            return View(movie);
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            List<Movie> allMovies = Client.GetMovies();
            var movie = allMovies.Where(m => m.Id == id).FirstOrDefault();
            return View(movie);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Title,Director,Length")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Client.ModifyMovie(movie);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View("NoRunning");
                }
            }
            return View(movie);
        }

        // GET: BookController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<Movie> allMovies = Client.GetMovies();
            var movie = allMovies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: BookController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            List<Movie> allMovies = Client.GetMovies();
            var movie = allMovies.Where(m => m.Id == id).FirstOrDefault();
            try
            {
                Client.DeleteMovie(movie.Id);
            }
            catch (Exception ex)
            {
                return View("NoRunning");
            }
            return RedirectToAction(nameof(Index));
        }

        public string Next(int id)
        {
            return Client.GetNextMovie(id);
        }
    }
}

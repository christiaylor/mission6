using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission6.Models;

namespace mission6.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoviesContext _context;

        public HomeController(MoviesContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }



        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View("NewMovie", new Movie());
        }

        [HttpPost]
        public IActionResult NewMovie(Movie response)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList(); // Ensure ViewBag is set
                return View("NewMovie", response);
            }

            _context.Movies.Add(response);
            _context.SaveChanges();

            return RedirectToAction("SeeMovies"); // Redirect to avoid resubmission issues
        }


        [HttpGet]
        public IActionResult SeeMovies()
        {
            var movies = _context.Movies
                .OrderBy(x => x.Year).ToList();
                
            return View(movies);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
            .ToList();

            return View("NewMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("SeeMovies");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("SeeMovies");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

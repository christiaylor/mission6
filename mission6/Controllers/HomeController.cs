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
            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(Movie response)
        {
            _context.Movies.Add(response); // Add record to database
            _context.SaveChanges();

            return View("NewMovie", response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

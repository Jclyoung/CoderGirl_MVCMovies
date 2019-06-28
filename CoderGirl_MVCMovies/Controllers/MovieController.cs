using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        //private static Dictionary<int, string> movies = new Dictionary<int, string>();
        public static List<Movie> movies = new List<Movie>();
        private  static int movieIdToUse = 1;

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Movies = movies;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string movie)
        {
            Movie movieName = new Movie { MovieId = movieIdToUse, MovieName = movie };
            movies.Add(movieName);
            movieIdToUse++;
            return RedirectToAction(actionName: nameof(Index));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        public static Dictionary<int, string> movies = new Dictionary<int, string>();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}

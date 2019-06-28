using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private static MovieRatingRepository repository = 
            (MovieRatingRepository)RepositoryFactory.GetMovieRatingRepository();

        public static List<Movie> movies = MovieController.movies;

        //private string htmlForm = @"
        //    <form method='post'>
        //        <input name='movieName' />
        //        <select name='rating'>
        //            <option>1</option>
        //            <option>2</option>
        //            <option>3</option>
        //            <option>4</option>
        //            <option>5</option>                    
        //        </select>
        //        <button type='submit'>Rate it</button>
        //    </form>";




       
        public IActionResult Index()
        {
            var getMovieRatingId = repository.GetMovieRatings();
            ViewBag.Movies = getMovieRatingId;
            return View();
        }

        
        
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Movies = MovieController.movies;
            return View();
        }

        [HttpPost]
        public IActionResult Create(string movieName, string rating)
        {
            repository.SaveRating(movieName, Convert.ToDouble(rating));  
            return RedirectToAction(actionName: nameof(Details), routeValues: new { movieName, rating });
        }


        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            ViewBag.MovieName = movieName;
            ViewBag.Rating = Convert.ToDouble(rating);
            return View();
        }
    }
}


// Create a view Index. This view should list a table of all saved movie names with associated average rating
// Be sure to include headers for Movie and Rating
// Each tr with a movie rating should have an id attribute equal to the id of the movie rating
// Create a view MovieRating/Create and put the htmlForm there. Remember that html in a view should not
// be a string. 
// Change this method to return that view. 
// Save the movie/rating in the MovieRatingRepository before redirecting to the Details page
// Redirect passing only the id of the created movie/rating
// The Details method should take an int parameter which is the id of the movie/rating to display.
// Create a Details view which displays the formatted string with movie name and rating in an h2 tag. 
// The Details view should include a link to the MovieRating/Index page
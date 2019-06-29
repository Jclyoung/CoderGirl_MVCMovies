using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository movieRatingRepository = RepositoryFactory.GetMovieRatingRepository();
        private IMovieRepository movieRepository = RepositoryFactory.GetMovieRepository();

        public IActionResult Index()
        {
            List<MovieRating> movieRatings = movieRatingRepository.GetMovieRatings();
            return View(movieRatings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Names = movieRepository
                .GetMovies()
                .Select(mn => mn.Name)
                .ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieRating movieRating)
        {
            movieRatingRepository.Save(movieRating);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            ViewBag.Movie = movieName;
            ViewBag.Rating = rating;
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieRating movieRating = movieRatingRepository.GetById(id);
            return View(movieRating);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieRating movieRating)
        {
            movieRating.Id = id;
            movieRatingRepository.Update(movieRating);
            return RedirectToAction(actionName: nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            movieRatingRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));

        }

    }

}
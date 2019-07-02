using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class DirectorController : Controller
    {
        public static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public IActionResult Index()
        {
            List<Director> directors = directorRepository.GetDirectors();
            return View(directors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Director director)
        {
            directorRepository.Save(director);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Director director = directorRepository.GetById(id);
            return View(director);
        }

        [HttpPost]
        public IActionResult Edit(int id, Director director)
        {
            director.Id = id;
            directorRepository.Update(director);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            directorRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {
        public static List<MovieModel> MovieList = new List<MovieModel>
        {
            new MovieModel
            {
                ID = 1,
                Name = "Interstellar",
                Genre = "Sci-fi",
                Rating = 8.8,
                Length = 124
            },
             new MovieModel
            {
                ID = 2,
                Name = "We are millers",
                Genre = "Comedy",
                Rating = 8.8,
                Length = 140
            },
              new MovieModel
            {
                ID = 3,
                Name = "Goodfellas",
                Genre = "Crime",
                Rating = 9,
                Length = 190
            }
        };

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Movies()
        {
            return View(MovieList);
        }
        public IActionResult MovieDetails(MovieModel Model)
        {
            var movie = MovieList.FirstOrDefault(m => m.ID == Model.ID);
            return View(movie);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(MovieModel model)
        {
            MovieList.Add(model);
            return View("Movies", MovieList);
        }
        public IActionResult Edit(int id)
        {
            var movie = MovieList.FirstOrDefault(m => m.ID == id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult UpdateMovie(MovieModel model)
        {
            var index = MovieList.FindIndex(i => i.ID == model.ID);
            MovieList[index] = model;
            return View("Movies", MovieList);
        }
        public IActionResult Delete(int id)
        {
            var movie = MovieList.FirstOrDefault(m => m.ID == id);
            return View(movie);
        }
        public IActionResult DeleteMovie(MovieModel model)
        {
            var movie = MovieList.FirstOrDefault(m => m.ID == model.ID);
            MovieList.Remove(movie);
            return View("Movies", MovieList);
        }
    }
}
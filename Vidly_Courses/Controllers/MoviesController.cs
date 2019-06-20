using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_Courses.Models;
using Vidly_Courses.ViewModels;

namespace Vidly_Courses.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(i => i.Id == id);
            return View(movies);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm",viewModel);
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres,
                Movie = movie
            };
            return View("MovieForm",viewModel);
        }

        public ActionResult Save(MovieFormViewModel viewModel)
        {
            if (viewModel.Movie.Id == 0)
            {
                viewModel.Movie.DateAdded = DateTime.Today;
                _context.Movies.Add(viewModel.Movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == viewModel.Movie.Id);

                movieInDb.Name = viewModel.Movie.Name;
                movieInDb.ReleaseDate = viewModel.Movie.ReleaseDate;
                movieInDb.GenreId = viewModel.Movie.GenreId;
                movieInDb.NumberInStock = viewModel.Movie.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pop.ly.Models.Database;
using Pop.ly.Models;


namespace Pop.ly.Controllers
{
    public class BrowseController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Browse
        public ActionResult Index(int? Year)
        {
            BrowseModel model = new BrowseModel();
            model.Populate();
            if ( Year != null )
            {
                model.grid.movies = db.Movies.Where(m => m.ReleaseYear == Year).Select(m => m).ToList();
            }
            return View(model);
        }
        public ActionResult Year(int Year)
        {
            BrowseModel model = new BrowseModel();
            model.grid.movies = db.Movies.Where(m => m.ReleaseYear == Year).Select(m => m).ToList();            
            return View(model);        
         
        }
        public ActionResult SortByGenre(string Genre)
        {
            MovieGridViewModel model = new MovieGridViewModel();
            model.movies = db.Movies.Where(g => g.Genre.Contains(Genre)).Select(g => g).ToList();
            model.ViewTitle = Genre;
            return PartialView("_MovieGridPartial",model);

        }
        public ActionResult Search(string Q)
        {
            MovieGridViewModel model = new MovieGridViewModel();
            int Year = 0;
            int.TryParse(Q, out Year);
            model.movies = db.Movies.Where(m => m.Description.Contains(Q) || m.Title.Contains(Q) || m.Genre.Contains(Q) || m.Director.Contains(Q) || m.ReleaseYear == Year).Select(m => m).ToList(); 
            return PartialView("_MovieGridPartial",model);
        }
    }
}
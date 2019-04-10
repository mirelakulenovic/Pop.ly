using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pop.ly.Models;
using Pop.ly.Models.Database;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Pop.ly.Controllers
{
    public class MovieController : Controller
    {
         ApplicationDbContext db = new ApplicationDbContext();       
        // GET: Movie
        public ActionResult Index(string T, int Y)
        {
            //Creates an object out of the view model, you can find it in Models/Database/Movies
            MovieIndexViewModel model = new MovieIndexViewModel();
            //Fetches a movie object from database
            Movie movieObject = db.Movies.Where(m => m.Title == T && m.ReleaseYear == Y).Select(m => m).First();
            //Fetches list of reviews from database
            var movieReviews = db.Reviews.Where(r => r.MovieID == movieObject.ID).Select(r => r).ToList();
            //Adds the movie object into the view model object
            model.Movie = movieObject;
            //Adds the list of reviews into the view model object
            model.Reviews = movieReviews;
            //Passes the view model object into the view
            return View(model);
        }
        public ActionResult temp()
        {
            Movie model = db.Movies.Where(m => m.Title == "Interstellar").Select(m => m).FirstOrDefault();
            return View(model);
        }
        public ActionResult CreateReview(int ReviewedMovieID, int ReviewScore, string ReviewContent)
        {
            var User = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            Review MovieReview = new Review
            {
                MovieID = ReviewedMovieID,
                Rating = ReviewScore,
                Comment = ReviewContent,
                UserID = User.Id
            };
            db.Reviews.Add(MovieReview);
            db.SaveChanges();
            return null;
        }
        public ActionResult UpdateReviews(int MovieID)
        {
            IEnumerable<Review> model = db.Reviews.Where(r => r.MovieID == MovieID).Select(r => r);
            return PartialView("_CustomerReviewsPartial", model);
        }
       
    }
}
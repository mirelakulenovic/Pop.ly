using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pop.ly.Models.Database;
using Pop.ly.Models;

namespace Pop.ly.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManageOrders()
        {
            OrderAdminViewModel model = new OrderAdminViewModel();
            model.Populate();
            return View(model);
        }
        public ActionResult ManageMovies()
        {
            var model = db.Movies.Select(m => m);
            return View(model);
        }
        public ActionResult ManageCustomers()
        {
            var model = db.Users.Select(u => u).ToList();
            return View(model);
        }
        public ActionResult CustomerDetails(string M)
        {
            CustomerAdminViewModel model = new CustomerAdminViewModel();
            model.Customer = db.Users.Where(u => u.Email == M).Select(u => u).FirstOrDefault();
            model.Orders.PopulateFromCustomer(model.Customer.Id);
            return View(model);
        }
        [HttpGet]
        public ActionResult AddMovie()
        {
            AddMovieViewModel model = new AddMovieViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddMovie(AddMovieViewModel obj)
        {
            Movie.SaveMovieToDB(obj.Movie);
            obj.MovieAdded = true;
            obj.Message = "The movie has been added";
            return View(obj);
        }
    }
}
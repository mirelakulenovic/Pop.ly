using Pop.ly.Models;
using Pop.ly.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pop.ly
{
    public class MvcApplication : System.Web.HttpApplication
    {
        ApplicationDbContext db = new ApplicationDbContext();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var movies = db.Movies.Select(m => m);
            foreach (var movie in movies)
            {
                movie.UpdateMovieRating();
            }
        }
    }
}

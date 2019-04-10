using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pop.ly.Models;
using Pop.ly.Models.Database;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace Pop.ly.Models
{
    public class HomeIndexVieWModel
    {
        public Random r = new Random();
        ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<Movie> Carousel { get; set; }
        [Display(Name ="Hot Items")]
        public IEnumerable<Movie> Popular { get; set; }
        [Display(Name = "New Releases")]
        public IEnumerable<Movie> RecentlyReleased { get; set; }
        [Display(Name = "Old Favourites")]
        public IEnumerable<Movie> OldestMovies { get; set; }
        [Display(Name = "Great Deals")]
        public IEnumerable<Movie> CheapestMovies { get; set; }


        public void Populate()
        {
            Carousel = db.Movies.OrderBy(m => Guid.NewGuid()).Take(3);
            var Rows = db.OrderRows.OrderByDescending(r => r.Quantity).Select(r=>r).ToList();
            Dictionary<int, int> DictPopItems = new Dictionary<int, int>();
            foreach (var row in Rows)
            {
                if (DictPopItems.ContainsKey(row.MovieID) == false)
                {
                    DictPopItems.Add(row.MovieID, row.Quantity);
                }
                else
                {
                    var amount = DictPopItems[row.MovieID] + row.Quantity;
                    DictPopItems[row.MovieID] = amount;
                }
            }
            var PopItems = new List<int>(DictPopItems.Keys);
            Popular = db.Movies.Where(m => PopItems.Contains(m.ID));
            RecentlyReleased = db.Movies.Where(m => m.ReleaseYear >= DateTime.Now.Year -1);
            OldestMovies = db.Movies.OrderBy(m => m.ReleaseYear).Select(m => m).Take(12).ToList();
            CheapestMovies = db.Movies.OrderBy(m => m.Price).Select(m => m).Take(12).ToList();
        }
    }
}
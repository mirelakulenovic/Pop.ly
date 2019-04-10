using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Pop.ly.Models;
using System.Data.Entity.Migrations;

namespace Pop.ly.Models.Database
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        //Changes the display
        [Display(Name = "Release Year"), Required]
        public int ReleaseYear { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Genre { get; set; }
        [Display(Name = "Synopsis"), Required]
        public string Description { get; set; }
        //Sets the maximum range. 
        [Range(0,5)]
        public int Rating { get; set; } = 0;
        [Required]
        public decimal Price { get; set; }
        [Display(Name="Cover artwork"),Required]
        public string CoverArt { get; set; }
        [Display(Name = "Promotional artwork"),Required]
        public string PromoArt { get; set; }
        [Display(Name = "Trailer URL"),Required]
        public string TrailerURL { get; set; }

        //Adds movie to database. Returns true upon successful addition.
        public static bool SaveMovieToDB(Movie obj)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //Queries database to see whether the movie already exists. Naturally this is not a perfect check since you could typo the title or the release year
            var QueryDB = db.Movies.Where(m => m.Title == obj.Title && m.ReleaseYear == obj.ReleaseYear).Any();
            if (QueryDB != true)
            {
                //Adds the created movie and saves the changes
                db.Movies.Add(obj);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        //Deletes movie from database based on the ID provided. Returns true upon successful deletion.
        public static bool DeleteMovieFromDB(int ID)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var QueryDB = db.Movies.Where(m => m.ID == ID).Any();
            if (QueryDB != true)
            {
                db.Movies.Remove(db.Movies.Where(m => m.ID == ID).Select(m => m).First());
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        //Updates movie rating
        public void UpdateMovieRating()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var Reviews = db.Reviews.Where(r => r.MovieID == this.ID).Select(r => r.Rating).ToList();
            int TotalRating = 0;
            foreach (var score in Reviews)
            {
                TotalRating = TotalRating + score;
            }
            if (TotalRating != 0 && Reviews.Count() != 0)
            {
                this.Rating = TotalRating / Reviews.Count();
                db.Movies.AddOrUpdate(this);
                db.SaveChanges();
            }
        }
    }
    public class MovieIndexViewModel
    {
        public Movie Movie { get; set; }
        public List<Review> Reviews { get; set; }
        public Review Review = new Review();
    }
}
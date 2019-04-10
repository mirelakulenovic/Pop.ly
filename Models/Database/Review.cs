using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pop.ly.Models.Database
{
    public class Review
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int MovieID { get; set; }
        [Range(0,5)]
        public int Rating { get; set; }
        public string Comment { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
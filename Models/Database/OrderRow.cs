using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pop.ly.Models.Database
{
    public class OrderRow
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int MovieID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Order Order { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
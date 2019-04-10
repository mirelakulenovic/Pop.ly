using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pop.ly.Models.Database;
using Pop.ly.Models;

namespace Pop.ly.Models
{
    public class AdministrationViewModels
    {
    }
    public class OrderAdminViewModel
    {
        public List<OrderViewModel> AllOrders = new List<OrderViewModel>();

        public void Populate()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var AllOrders = db.Orders.Select(o => o.ID).ToList();
            foreach (var ID in AllOrders)
            {
                OrderViewModel obj = new OrderViewModel()
                {
                    Order = db.Orders.Where(o => o.ID == ID).Select(o => o).FirstOrDefault(),
                    OrderRows = db.OrderRows.Where(r => r.Order.ID == ID).Select(r => r).ToList()
                };
                foreach (var row in obj.OrderRows)
                {
                    obj.TotalCost = obj.TotalCost + row.Price;
                }
                
                this.AllOrders.Add(obj);
            }
        }
        public void PopulateFromCustomer(string UserID)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var AllOrders = db.Orders.Where(o => o.User.Id == UserID).Select(o => o.ID).ToList();
            foreach (var ID in AllOrders)
            {
                OrderViewModel obj = new OrderViewModel()
                {
                    Order = db.Orders.Where(o => o.ID == ID).Select(o => o).FirstOrDefault(),
                    OrderRows = db.OrderRows.Where(r => r.Order.ID == ID).Select(r => r).ToList()
                };
                foreach (var row in obj.OrderRows)
                {
                    obj.TotalCost = obj.TotalCost + row.Price;
                }

                this.AllOrders.Add(obj);
            }
        }
    }
    public class CustomerAdminViewModel
    {
        public ApplicationUser Customer { get; set; }
        public OrderAdminViewModel Orders = new OrderAdminViewModel();
    }

    public class AddMovieViewModel
    {
        public Movie Movie { get; set; }
        public string Message { get; set; }
        public bool MovieAdded { get; set; } = false;
    }
}
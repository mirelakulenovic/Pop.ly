using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pop.ly.Models.Database;
using System.ComponentModel.DataAnnotations;

namespace Pop.ly.Models
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public Movie Movie { get; set; }
        public decimal CostPerItem { get; set; }
    }

    public class ShoppingCart
    {
        public decimal TotalCost { get; set; }
        public List<CartItem> Items = new List<CartItem>();


        //Calculates the total cost of all items in the cart
        public void CalculateTotal()
        {
            TotalCost = 0;
            foreach (var i in this.Items)
            {
                TotalCost += i.CostPerItem * i.Quantity;
            }
        }
        //Method takes a cart and a customer and creates an order, as well as appropriate rows out of it.
        public static void CreateOrder(string UserID, ShoppingCart Cart, string FirstName, string LastName, string Address, string Zip, string City)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Order NewOrder = new Order
            {
                Recipient = FirstName + " " + LastName,
                DeliveryAddress = Address,
                DeliveryZip = Zip,
                DeliveryCity = City,
                User = db.Users.Find(UserID),
                OrderDate = DateTime.Now
            };
            NewOrder.OrderRows = new List<OrderRow>();
            foreach (var item in Cart.Items)
            {
                OrderRow row = new OrderRow
                {

                    MovieID = item.Movie.ID,
                    Price = item.CostPerItem * item.Quantity,
                    Quantity = item.Quantity
                };
                NewOrder.OrderRows.Add(row);
            }


            db.Orders.Add(NewOrder);
            db.SaveChanges();
        }
    }

    public class CheckoutViewModel
    {
        public ApplicationUser User { get; set; }
        [Display(Name = "Recipient Name")]
        public string RecipientName { get; set; }
        [Display(Name = "Recipient Surname")]
        public string RecipientSurname { get; set; }
        [Display(Name = "Address")]
        public string ShippingAddress { get; set; }
        [Display(Name = "Zip")]
        public string ShippingZip { get; set; }
        [Display(Name = "City")]
        public string ShippingCity { get; set; }
        [Display(Name = "Ship to billing address")]
        public bool ShipToUser { get; set; } = true;
        public bool OrderCreated = false;
        public ShoppingCart Cart { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pop.ly.Models;
using Pop.ly.Models.Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Pop.ly.Controllers
{
    public class ShoppingCartController : Controller
    {
        protected UserManager<ApplicationUser> UserManager { get; set; }
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart();
            if (Session["Cart"] != null)
            {
                cart = (ShoppingCart)Session["Cart"];
            }
            return View(cart);
        }
        //Handles adding new items to the cart, it needs the Movie's ID to function
        public ActionResult AddToCart(int movieID)
        {
            //Creates an instance of a cart
            ShoppingCart cart = new ShoppingCart();
            //Checks whether a cart exists in the session, if so it sets this new cart instance to be identical to the cart in the session
            //We do this so we don't overwrite the cart, otherwise we'd never be able to add more than one item to the cart
            if (Session["Cart"] != null)
            {
                cart = (ShoppingCart)Session["Cart"];
            }
            //Instantiates a movie object by using the movie ID we passed into the function to query the database
            Movie SelectedMovie = db.Movies.Where(m => m.ID == movieID).Select(m => m).First();
            //Creates a new cart item

            var existingItem = cart.Items.SingleOrDefault(i => i.Movie.ID == movieID);

            if (existingItem != null)
            {
                //filmen finns redan i cart


                existingItem.Quantity++;

            }
            else
            {
                //filmen finns INTE i cart

                CartItem item = new CartItem
                {
                    Movie = SelectedMovie,
                    Quantity = 1,
                    CostPerItem = SelectedMovie.Price
                };
                //Adds the cart item to our cart
                cart.Items.Add(item);
            }
            //Passes our cart into the session
            cart.CalculateTotal();
            Session["Cart"] = cart;
            return null;
        }
        //Handles removing existing items from the cart
        public ActionResult RemoveFromCart(int index)
        {
            ShoppingCart cart = new ShoppingCart();
            if (Session["Cart"] != null)
            {
                cart = (ShoppingCart)Session["Cart"];
            }
            if (cart.Items.Count() >= 1)
            {
                cart.Items.RemoveAt(index);
            }
            cart.CalculateTotal();
            Session["Cart"] = cart;
            return PartialView("_CartPartial", cart);
        }
        //Increments an item in the cart by one
        public ActionResult IncreaseItemQuantity(int movieID)
        {
            //Creates an instance of a cart
            ShoppingCart cart = new ShoppingCart();
            //Checks whether a cart exists in the session, if so it sets this new cart instance to be identical to the cart in the session
            //We do this so we don't overwrite the cart, otherwise we'd never be able to add more than one item to the cart
            if (Session["Cart"] != null)
            {
                cart = (ShoppingCart)Session["Cart"];
            }
            //Instantiates a movie object by using the movie ID we passed into the function to query the database
            Movie SelectedMovie = db.Movies.Where(m => m.ID == movieID).Select(m => m).First();
            //Creates a new cart item

            var existingItem = cart.Items.SingleOrDefault(i => i.Movie.ID == movieID);

            if (existingItem != null)
            {
                //filmen finns redan i cart
                existingItem.Quantity++;
            }
            else
            {
                //filmen finns INTE i cart
                CartItem item = new CartItem
                {
                    Movie = SelectedMovie,
                    Quantity = 1,
                    CostPerItem = SelectedMovie.Price
                };
                //Adds the cart item to our cart
                cart.Items.Add(item);
            }
            //Passes our cart into the session
            cart.CalculateTotal();
            Session["Cart"] = cart;
            return PartialView("_CartPartial", cart);
        }
        //Decreases the amount of items in the cart
        public ActionResult DecreaseItemQuantity(int movieID)
        {
            ShoppingCart cart = new ShoppingCart();

            if (Session["Cart"] != null)
            {
                cart = (ShoppingCart)Session["Cart"];
            }
            Movie SelectedMovie = db.Movies.Where(m => m.ID == movieID).Select(m => m).First();

            var existingItem = cart.Items.SingleOrDefault(i => i.Movie.ID == movieID);

            //So long as the quantity of the item is larger than one, you can reduce it.
            //If the quantity is 1, you remove the item. Else you'd end up having to pay the customer for ordering a negative amount of movies
            if (existingItem.Quantity > 1)
            {

                existingItem.Quantity--;
            }
            else
            {
                cart.Items.Remove(existingItem);
            }
            cart.CalculateTotal();
            Session["Cart"] = cart;
            return PartialView("_CartPartial", cart);
        }
        //Checkout
        [Authorize]
        [HttpGet]
        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel();
            model.Cart = (ShoppingCart)Session["Cart"];
            model.User = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Checkout(CheckoutViewModel model)
        {
            model.Cart = (ShoppingCart)Session["Cart"];
            model.User = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ShoppingCart.CreateOrder(model.User.Id, model.Cart, model.RecipientName, model.RecipientSurname, model.ShippingAddress, model.ShippingZip, model.ShippingCity);
            model.OrderCreated = true;
            Session.Clear();
            return View(model);
        }
    }
}   




            


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pop.ly.Models.Database;
using Pop.ly.Models;

namespace Pop.ly.Controllers
{
    public class OrderController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Order
        public ActionResult Index(int OrderID)
        {
            List<OrderRow> model = db.OrderRows.Where(r => r.OrderID == OrderID).Select(r => r).ToList();
            return View(model);
        }
        public ActionResult Details(int OrderID)
        {
            List<OrderRow> model = db.OrderRows.Where(r => r.OrderID == OrderID).Select(r => r).ToList();
            return View(model);
        }
    }
}
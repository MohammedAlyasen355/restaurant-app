using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class ListsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lists
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}
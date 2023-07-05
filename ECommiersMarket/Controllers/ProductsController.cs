using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class ProductsController : Controller
    {
        ZahraMarketEntities db = new ZahraMarketEntities();
        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}
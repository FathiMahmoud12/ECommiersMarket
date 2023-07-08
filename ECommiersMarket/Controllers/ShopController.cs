using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class ShopController : Controller
    {
        ZahraMarketEntities db = new ZahraMarketEntities();
        // GET: Shop
        public ActionResult Index()
        {
            return View("Index",db.MainGroups.ToList());
        }
    }
}
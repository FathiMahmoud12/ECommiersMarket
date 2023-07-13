using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class AddStoreController : Controller
    {
        // GET: AddStore
        ZahraMarketEntities db = new ZahraMarketEntities();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Store s)
        {
            db.Stores.Add(s);
            db.Stores.ToList();
                
                return View();
        }
    }
}
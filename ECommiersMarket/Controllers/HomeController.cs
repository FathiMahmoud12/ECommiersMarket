using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers

{
    public class HomeController : Controller
    {
        ZahraMarketEntities db = new ZahraMarketEntities();

        public ActionResult Index()
        {
            ViewBag.MAinGroupsCount = db.MainGroups.Count();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
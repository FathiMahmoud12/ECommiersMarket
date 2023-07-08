using ECommiersMarket.Models;
using FirstSelection.Authorization;
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
            ViewBag.Prod = db.Products.Count();

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
        public ActionResult SignOut()
        {
            VTSAuth auth = new VTSAuth();
            auth.LoadDataFromCookies();
            auth.ClearCookies();
            return RedirectToAction("Index", "LoginPage");
        }
    }
}
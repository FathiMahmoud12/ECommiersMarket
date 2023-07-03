using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommiersMarket.Models;

namespace ECommiersMarket.Controllers
{
    ZahraMarketEntities db = new ZahraMarketEntities();

    public class MainGroupController : Controller
    {
        // GET: MainGroup
        public ActionResult Index()
        {
            return View();
        }
    }
}
using ECommiersMarket.Models;
using Elmorshedi_Candels.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class ShopListController : BaseController
    {
        ZahraMarketEntities db = new ZahraMarketEntities();

        // GET: ShopList
        public ActionResult Index()
        {
            return View();
        }
    }
}
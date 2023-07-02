using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Models
{
    public class GroupsController : Controller
    {
    ZahraMarketEntities db = new ZahraMarketEntities();
        // GET: Groups
        public ActionResult Index()
        {
         var Groupps= db.MainGroups.ToList();
            return View(Groupps);
        }  
      
    }
}
using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class SubGroupsController : Controller
    {
        // GET: SubGroups
        ZahraMarketEntities db = new ZahraMarketEntities();

        public ActionResult Index()
        {
            return View(db.SubGroupsTs.ToList());
        }
        [HttpPost]
        public ActionResult Edit(int Id, SubGroupsT gg)
        {

           
            db.SaveChanges();
            return View("Index", db.SubGroupsTs.ToList());
        }
        public ActionResult Delete(int Id)
        {
            var Groupps = db.SubGroupsTs.Find(Id);
            db.SubGroupsTs.Remove(Groupps);
            TempData["success"] = "تم حذف البيانات بنجاح";
            return View(Groupps);
        }
    }
}
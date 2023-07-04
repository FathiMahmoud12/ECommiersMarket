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
        public ActionResult Edit(int Id)
        {
            var Groupps = db.SubGroupsTs.Find(Id);

            var Combo_Iteams = db.MainGroups.ToList();

            if (Combo_Iteams != null)
            {
                @ViewBag.data = Combo_Iteams;
            }
            return View("Edit", Groupps);

        }
        [HttpPost]
        public ActionResult Edit(int Id, SubGroupsT gg)
        {
            var Groupps = db.SubGroupsTs.Find(Id);
            Groupps.GroupID = gg.GroupID;
            Groupps.SubGroupName = gg.SubGroupName;

            db.SaveChanges();
            return View("Index", db.SubGroupsTs.ToList());
        }

        public ActionResult Delete(int Id)
        {
            var Groupps = db.SubGroupsTs.Find(Id);
            db.SubGroupsTs.Remove(Groupps);
            db.SaveChanges();
            TempData["success"] = "تم حذف البيانات بنجاح";
            db.SubGroupsTs.ToList();

            return RedirectToAction("Index");
        }
    }
}
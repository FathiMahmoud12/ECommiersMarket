using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class AddSupGroupController : Controller
    {
        // GET: AddGroups
        ZahraMarketEntities db = new ZahraMarketEntities();

        public ActionResult Index()
        {

            var Combo_Iteams = db.MainGroups.ToList();

            if (Combo_Iteams != null)
            {
                @ViewBag.data = Combo_Iteams;
            }
            return View();
        }
        [HttpPost]
        public ActionResult ADD_SubGroups(SubGroupsT MG)
        {
            MG.IsDeletedd = false;
       
            db.SubGroupsTs.Add(MG);
            db.SaveChanges();
            TempData["success"] = "تم حفظ البيانات بنجاح";

            var Groupps = db.MainGroups.ToList();
            return View("Index", Groupps);
        }
    }
}
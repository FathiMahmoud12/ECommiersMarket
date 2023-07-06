using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class AddProductController : Controller
    {
        ZahraMarketEntities db = new ZahraMarketEntities();
        // GET: AddProduct
        public ActionResult Index()
        {
            var Combo_Iteams = db.MainGroups.ToList();

            if (Combo_Iteams != null)
            {
                @ViewBag.data = Combo_Iteams;
            }
            @ViewBag.SupGroup = new SelectList("");

            return View();
        }
        public ActionResult getCats(int Id)
        {
            var model = db.SubGroupsTs.Where(x => x.GroupID == Id).Select(x => new { x.Id, x.SubGroupName }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}
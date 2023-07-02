using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class AddGroupsController : Controller
    {
        ZahraMarketEntities db = new ZahraMarketEntities();
        // GET: AddGroups
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ADD_gROUPS(MainGroup MG)
        {
            MG.IsDeleted = false;
            var ff = db.MainGroups.OrderByDescending(x => x.Id).FirstOrDefault();

            HttpPostedFileBase ProPicture = Request.Files["pi_path"];
            if (ff == null)
            {
                MG.pi_path = "/Uploads/ServicesAtt/" + "1";
            }
            else
            {
                MG.pi_path = "/Uploads/ServicesAtt/" + (ff.Id + 1);

            }
            if (!Directory.Exists(Server.MapPath(MG.pi_path)))
                Directory.CreateDirectory(Server.MapPath(MG.pi_path));
            MG.pi_path = MG.pi_path + "/" + MG.GroupName+ ".jpg";
            ProPicture.SaveAs(Server.MapPath(MG.pi_path));

            db.MainGroups.Add(MG);
            db.SaveChanges();
            TempData["success"] = "تم حفظ البيانات بنجاح";

            var Groupps = db.MainGroups.ToList();
            return View("Index", Groupps);
        }
    }
}
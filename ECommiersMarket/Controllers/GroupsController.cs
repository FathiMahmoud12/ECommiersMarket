using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Edit( int Id)
        {
            var Groupps = db.MainGroups.Find(Id);
            ViewBag.Picture = Groupps.pi_path;
            return View(Groupps);
        }  
        [HttpPost]
        public ActionResult Edit( int Id , MainGroup gg)
        {
       
            var ff = db.MainGroups.OrderByDescending(x => x.Id).FirstOrDefault();

            HttpPostedFileBase ProPicture = Request.Files["pi_path"];
            if (ff == null)
            {
                gg.pi_path = "/Uploads/ServicesAtt/" + "1";
            }
            else
            {
                gg.pi_path = "/Uploads/ServicesAtt/" + (ff.Id );

            }
            if (!Directory.Exists(Server.MapPath(gg.pi_path)))
                Directory.CreateDirectory(Server.MapPath(gg.pi_path));
            gg.pi_path = gg.pi_path + "/" + gg.GroupName + ".jpg";
            //ProPicture.(Server.MapPath(gg.pi_path));
            var Groupps = db.MainGroups.Find(Id);
            Groupps.GroupName = gg.GroupName;
            Groupps.pi_path = gg.pi_path;

            db.SaveChanges();
            return View("Index", db.MainGroups.ToList());
        }
        public ActionResult Delete(int Id)
        {
            var Groupps = db.MainGroups.Find(Id);
            db.MainGroups.Remove(Groupps);
            TempData["success"] = "تم حذف البيانات بنجاح";
            return View(Groupps);
        }

    }
}
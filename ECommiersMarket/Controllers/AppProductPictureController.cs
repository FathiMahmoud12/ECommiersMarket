using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class AppProductPictureController : Controller
    {
        // GET: AppProductPicture
        ZahraMarketEntities db = new ZahraMarketEntities();
        public ActionResult Index()
        {
            var Combo_Iteams = db.Products.ToList();

            if (Combo_Iteams != null)
            {
                @ViewBag.data = Combo_Iteams;
            }
            return View(db.ProductPictures.ToList());
        }  
        public ActionResult AddProdPic( ProductPicture pp )
        {
            try
            {
                var fi = db.Products.Find(pp.ProductId);
                var ff = db.ProductPictures.OrderByDescending(x => x.Id).FirstOrDefault();

                HttpPostedFileBase ProPicture = Request.Files["pi_path"];
                if (ff == null)
                {
                    pp.pi_path = "/Uploads/ServicesAtt/" + "1";
                }
                else
                {
                    pp.pi_path = "/Uploads/ServicesAtt/" + (ff.Id);

                }
                if (!Directory.Exists(Server.MapPath(pp.pi_path)))
                    Directory.CreateDirectory(Server.MapPath(pp.pi_path));
                pp.pi_path = pp.pi_path + "/" + fi.ProductName + ".jpg";
                ProPicture.SaveAs(Server.MapPath(pp.pi_path));

                //ProductPicture ppp = new ProductPicture()
                //{
                //    ProductId = p.ID,
                //    pi_path = pp.pi_path
                //};
                db.ProductPictures.Add(pp);
                db.SaveChanges();
                var Combo_Iteams = db.Products.ToList();

                if (Combo_Iteams != null)
                {
                    @ViewBag.data = Combo_Iteams;
                }
                TempData["success"] = "تم حفظ البيانات بنجاح";

            }
            catch (Exception ex)
            {
                TempData["success"] = "حدثت مشكلة اثناء رفع الصورة ";


            }
            return RedirectToAction("Index", "AppProductPicture");
        }
        public ActionResult Delete(int Id)
        {
            var Groupps = db.ProductPictures.Find(Id);
            db.ProductPictures.Remove(Groupps);
            TempData["success"] = "تم حذف البيانات بنجاح";
            
            return RedirectToAction("Index", db.ProductPictures.ToList());
        }

    }
}
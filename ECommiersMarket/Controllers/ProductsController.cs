using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class ProductsController : Controller
    {
        ZahraMarketEntities db = new ZahraMarketEntities();
        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public ActionResult Edit(int Id)
        {
            var Groupps = db.Products.Find(Id);
            
            return View(Groupps);
        }
        [HttpPost]
        public ActionResult Edit(int Id, Product gg)
        {

      
            var Groupps = db.Products.Find(Id);
            Groupps.ProductName = gg.ProductName;
            Groupps.SupGroup = gg.SupGroup;
            Groupps.Price = gg.Price;
            Groupps.Qnt = gg.Qnt;
            Groupps.Notes = gg.Notes;

            db.SaveChanges();
            db.Products.ToList();
            return View("Index");
        }
        public ActionResult Delete(int Id)
        {
            var Groupps = db.Products.Find(Id);
            db.Products.Remove(Groupps);
            TempData["success"] = "تم حذف البيانات بنجاح";
            return View(Groupps);
        }

    }

}
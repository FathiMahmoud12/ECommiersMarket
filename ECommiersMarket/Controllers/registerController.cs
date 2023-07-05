using ECommiersMarket.Models;
using FirstSelection.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class registerController : Controller
    {
        ZahraMarketEntities db = new ZahraMarketEntities();
        // GET: register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveInfo(User_Reg_Info u)
        {
            var pass = Security.Encrypt(u.userpassword);
            //var FindUsername = db.User_Reg_Info.Where(x => x.username == u.username && x.userpassword == pass).FirstOrDefault();

            User uu = new User()
            {
                Id = Guid.NewGuid(),
                UserName = u.username,
                Password = pass,
                IsActive = true,
                RoleId = 2

            };
            db.Users.Add(uu);
            db.SaveChanges();

            TempData["success"] = " تم حفظ البيانات بنجاح الرجاء تسجيل الدخول ";

            return RedirectToAction("Index", "LoginPage");
        }

    }
}
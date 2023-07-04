
using ECommiersMarket.Models;
using FirstSelection.Authorization;
using FirstSelection.Enums;
using FirstSelection.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ECommiersMarket.Controllers
{
    public class LoginPageController : Controller
    {
        ZahraMarketEntities db = new ZahraMarketEntities();
        // GET: LoginPage
        public ActionResult Index()
        {
            VTSAuth auth = new VTSAuth();
            var check = auth.CheckCookies();

            return View();
        }
        [HttpPost]
        public ActionResult LoginpageComfirm(User u)
        {
            var pass = Security.Encrypt(u.Password);
            var FindUsername = db.Users.Where(x => x.UserName == u.UserName && x.Password == pass).FirstOrDefault();
            if (FindUsername != null)
            {
                VTSAuth auth = new VTSAuth();
                var user = new UserInfo
                {
                    UserId = FindUsername.Id,
                    RoleId = (Role)FindUsername.RoleId,
                    UserName = FindUsername.UserName,
                };

                auth.SaveToCookies(user);

                string returnUrl = Request.QueryString["returnUrl"];
                if (!string.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);

                else if (user.RoleId == Role.SystemAdmin)
                {
                    TempData["success"] = "تم حفظ البيانات بنجاح";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["success"] = "تم حفظ البيانات بنجاح";
                    return RedirectToAction("Index", "WelcomeForm");
                }

            }
            else
            {
                return RedirectToAction("Loginpage", "Login");

            }
        }

    }
}
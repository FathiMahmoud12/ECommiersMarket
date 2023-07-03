using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class WelcomeFormController : Controller
    {
        // GET: WelcomeForm
        public ActionResult Index()
        {
            return View();
        }
    }
}
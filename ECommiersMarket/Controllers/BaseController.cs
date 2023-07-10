using ECommiersMarket.Models;
using FirstSelection.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elmorshedi_Candels.Controllers
{
    public class BaseController : Controller
    {
        ZahraMarketEntities db = new ZahraMarketEntities();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var controller = filterContext.Controller as Controller;
            if (controller != null)
            {
                VTSAuth auth = new VTSAuth();
                
                    if (auth.LoadDataFromCookiesCart() != null)
                    {
                        var i = 0;
                        foreach (var item in auth.LoadDataFromCookiesCart())
                        {
                            i += (int)item.Count;
                        }
                        filterContext.Controller.ViewBag.Cart = auth.LoadDataFromCookiesCart().ToList();
                        filterContext.Controller.ViewBag.CartCount = i;
                        filterContext.Controller.ViewBag.Sum = auth.LoadDataFromCookiesCart().Sum(x=>x.Price);

                    }
                filterContext.Controller.ViewBag.SubGroups = db.SubGroupsTs.ToList();




            }

        }

    }
}
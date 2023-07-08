using ECommiersMarket.DTO;
using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class ShopController : Controller
    {
        ZahraMarketEntities db = new ZahraMarketEntities();
        // GET: Shop
        public ActionResult Index()
        {
            // المجموعات الفرعية 
            var model = db.SubGroupsTs.Select(x => new SupGroupsDTO
            {
                Id = x.Id,
                SupGroupName = x.SubGroupName
            }).ToList();

            ViewBag.SupGroups = model;
            // الاصناف 
            var Pro = db.Products.Select(x => new ProductShowingDTO
            {
                Id = x.ID,
                ProdName = x.ProductName,
                Price = (int)x.Price,
                ProductImages = x.ProductPictures.Select(y => new ProductsImagesDto
                {
                    Img = y.pi_path

                }).ToList()

            }).ToList();
            ViewBag.Iteams = Pro;


            return View("Index",db.MainGroups.ToList());
        }
    }
}
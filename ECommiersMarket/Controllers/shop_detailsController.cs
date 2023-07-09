using ECommiersMarket.DTO;
using ECommiersMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommiersMarket.Controllers
{
    public class shop_detailsController : Controller
    {
        ZahraMarketEntities db = new ZahraMarketEntities();
        // GET: shop_details
        public ActionResult Index(int Id)
        {
            var Pro = db.Products.Where(x=>x.ID == Id).Select(x => new ProductShowingDTO
            {
                Id = x.ID,
                ProdName = x.ProductName,
                Price = (int)x.Price,
                Note = x.Notes,
                ProductImages = x.ProductPictures.Select(y => new ProductsImagesDto
                {
                    Img = y.pi_path

                }).ToList()

            }).ToList();
            ViewBag.Iteams = Pro;
            return View("Index",db.Products.ToList());
        }
    }
}
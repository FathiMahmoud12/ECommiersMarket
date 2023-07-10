using ECommiersMarket.DTO;
using ECommiersMarket.Models;
using Elmorshedi_Candels.Controllers;
using FirstSelection.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Elmorshedi_Candels.Controllers.BaseController;

namespace ECommiersMarket.Controllers
{
    public class ShopController : BaseController
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

        public ActionResult AddItem(int id)
        {

            VTSAuth authr = new VTSAuth();
            var check = authr.CheckCookies();

            if (check == true)
            {
                using (var dbContext = new ZahraMarketEntities())
                {
                    string ProductName = dbContext.Products.Where(x => x.ID == id).Select(x => x.ProductName).FirstOrDefault();
                    var item = dbContext.Products.Where(x => x.ID == id).FirstOrDefault();

                    VTSAuth auth = new VTSAuth();

                    if (auth.CheckCookiesCart())
                    {
                        var ProductsInCart = auth.LoadDataFromCookiesCart();
                        if (ProductsInCart != null)
                        {
                            if (!ProductsInCart.Any(x => x.Id == id))
                            {
                                UserProducts item2 = new UserProducts();
                                item2.Id = id; item2.Name = item.ProductName; item2.Price = item.Price; item2.Count = 1; item2.Image = item.ProductPictures.Select(x => x.pi_path).FirstOrDefault();
                                ProductsInCart.Add(item2);
                                auth.SaveToCookiesCart(ProductsInCart);
                            }

                            else
                            {
                                var Item = ProductsInCart.Find(x => x.Id == id);
                                Item.Count += 1;
                                auth.SaveToCookiesCart(ProductsInCart);

                            }
                        }
                        else
                        {
                            ProductsInCart.Add(new UserProducts
                            {
                                Id = id,
                                Name = item.ProductName,
                                Price = item.Price,
                                Count = 1,
                                Image = item.ProductPictures.Select(x => x.pi_path).FirstOrDefault()
                            });
                            auth.SaveToCookiesCart(ProductsInCart);

                        }



                    }
                    else
                    {
                        List<UserProducts> UserProduct = new List<UserProducts>();
                        UserProduct.Add(new UserProducts { Id = id, Name = item.ProductName, Price = item.Price, Count = 1, Image = item.ProductPictures.Select(x => x.pi_path).FirstOrDefault() });
                        auth.SaveToCookiesCart(UserProduct);


                    }

                    return RedirectToAction("Index");

                }
            }
            else
            {
                TempData["info"] = "لم يتم تسجيل الدخول ";

                return RedirectToAction("Index", "LoginPage"); 
            }
        }


        public ActionResult RemoveItem(int id)
        {
            using (var dbContext = new ZahraMarketEntities())
            {
                VTSAuth auth = new VTSAuth();

                if (auth.CheckCookiesCart())
                {

                    var ProductsInCart = auth.LoadDataFromCookiesCart();
                    if (ProductsInCart != null)
                    {
                        ProductsInCart.RemoveAll(x => x.Id == id);
                        auth.SaveToCookiesCart(ProductsInCart);

                    }
                }

                return RedirectToAction("Home");
            }
        }

        public ActionResult DecItem(int id)
        {
            using (var dbContext = new ZahraMarketEntities())
            {
                VTSAuth auth = new VTSAuth();

                if (auth.CheckCookiesCart())
                {
                    var ProductsInCart = auth.LoadDataFromCookiesCart();
                    if (ProductsInCart != null)
                    {
                        var Item = ProductsInCart.Find(x => x.Id == id);
                        if (Item.Count <= 1)
                        {
                            ProductsInCart.RemoveAll(x => x.Id == id);
                            auth.SaveToCookiesCart(ProductsInCart);
                        }
                        else
                        {
                            Item.Count -= 1;
                            auth.SaveToCookiesCart(ProductsInCart);
                        }

                    }
                }

                return RedirectToAction("Index");

            }
        }

        public ActionResult IncItem(int id)
        {
            using (var dbContext = new ZahraMarketEntities())
            {
                VTSAuth auth = new VTSAuth();

                if (auth.CheckCookiesCart())
                {
                    var ProductsInCart = auth.LoadDataFromCookiesCart();
                    if (ProductsInCart != null)
                    {
                        var Item = ProductsInCart.Find(x => x.Id == id);

                        Item.Count += 1;
                        auth.SaveToCookiesCart(ProductsInCart);
                    }
                }

                return RedirectToAction("Index");

            }

        }
        public class UserProducts
        {
            public int Id { get; set; }
            //public string ImagePath { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public double? Price { get; set; }
            public int? Count { get; set; }


        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommiersMarket.DTO
{
    public class ProductShowingDTO
    {
        public int Id { get; set; }
        public int SupGroupId { get; set; }
        public string ProdName { get; set; }
        public string Note { get; set; }
        public int Price { get; set; }
        public List<ProductsImagesDto> ProductImages { get; set; }

    }

    public class ProductsImagesDto
    {
        public string Img { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAo.Models
{
    public class ProductViewModel
    {
        public List<ProductDto> ListProduct { get; set; }
        public List<ProductDto> ListProductHot { get; set; }

        public List<ProductDto> ListProductSale { get; set; }



    }
}
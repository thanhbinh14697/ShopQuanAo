using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAo.Models
{
    public class ProductCategoryViewModel
    {
        public List<ProductDto> Products { get; set; }
        public string CategoryName { get; set; }
    }
}
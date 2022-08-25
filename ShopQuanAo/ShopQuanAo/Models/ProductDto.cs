using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAo.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string NAMEPRODUCT { get; set; }
        public Nullable<int> PRICE { get; set; }
        public Nullable<int> LIKES { get; set; }
        public string IMAGELINK { get; set; }
    }
}
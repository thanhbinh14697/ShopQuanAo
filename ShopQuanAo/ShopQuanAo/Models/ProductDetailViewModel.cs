using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAo.Models
{
    public class ProductDetailViewModel
    {
        public List<Image> ListImage { get; set; }
        public Nullable<int> IDPRODUCT { get; set; }
        public string NAMEPRODUCT { get; set; }
        public Nullable<int> PRICE { get; set; }
        public Nullable<bool> STATUSS { get; set; }
        public Nullable<bool> SEX { get; set; }
        public string DESCRIPTIONS { get; set; }
        public string IMAGELINK { get; set; }
        public Nullable<int> LIKES { get; set; }
        public Nullable<int> IDCATEGORY { get; set; }
        public string NAMECATEGORY { get; set; }
    }
    public class Image
    {
        public string LINK { get; set; }
    }
}
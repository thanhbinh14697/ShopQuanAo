using Entity;
using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index(int idCategory)
        {
            ProductCategoryViewModel productCategoryViewModel = new ProductCategoryViewModel();
            List<ProductDto> productlist = new List<ProductDto>();
            using (var contex = new ShopQuanAoEntities())
            {
                var products = contex.Products.Where(pr => pr.IDCATEGORY == idCategory);
                foreach (var item in products)
                {
                    ProductDto product1 = new ProductDto()
                    {
                        IMAGELINK = item.IMAGELINK,
                        NAMEPRODUCT = item.NAMEPRODUCT,
                        PRICE = item.PRICE,
                        LIKES = item.LIKES,
                        Id = item.IDPRODUCT,
                    };
                    productlist.Add(product1);
                }
                var namevategory = contex.ProductCategories.FirstOrDefault(pr => pr.IDCATEGORY == idCategory);
                if (namevategory != null)
                {
                    productCategoryViewModel.CategoryName = namevategory.NAMECATEGORY;
                }
            }
           
            productCategoryViewModel.Products = productlist;
            return View(productCategoryViewModel);
        }

        public ActionResult Search(string keySearch)
        {
            ProductCategoryViewModel productCategoryViewModel = new ProductCategoryViewModel();
            List<ProductDto> productlist = new List<ProductDto>();
            using (var context = new ShopQuanAoEntities())
            {
                var searchProduct = from pr in context.Products
                                    where pr.NAMEPRODUCT.Contains(keySearch)
                                    select pr;
                foreach (var item in searchProduct)
                {
                    ProductDto product1 = new ProductDto()
                    {
                        IMAGELINK = item.IMAGELINK,
                        NAMEPRODUCT = item.NAMEPRODUCT,
                        PRICE = item.PRICE,
                        LIKES = item.LIKES,
                        Id = item.IDPRODUCT,
                    };
                    productlist.Add(product1);
                }
                productCategoryViewModel.Products = productlist;

            }
            return View(productCategoryViewModel);
        }
    }
}
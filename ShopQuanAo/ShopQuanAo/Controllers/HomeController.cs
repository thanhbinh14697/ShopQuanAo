using Entity;
using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<ProductDto> listpr = new List<ProductDto>();
            List<ProductDto> listpr2 = new List<ProductDto>();
            List<ProductDto> listpr3 = new List<ProductDto>();
            using (var context = new ShopQuanAoEntities())
            {
                var product = context.Products.Take(8);
                foreach (var item in product)
                {
                    ProductDto productDto = new ProductDto()
                    {
                        IMAGELINK = item.IMAGELINK,
                        NAMEPRODUCT = item.NAMEPRODUCT,
                        PRICE = item.PRICE,
                        LIKES = item.LIKES,
                        Id = item.IDPRODUCT,
                    };
                    listpr.Add(productDto);
                }

                var product2 = context.Products.OrderByDescending(pr => pr.LIKES).Take(8);
                foreach (var item in product2)
                {
                    ProductDto productDto = new ProductDto()
                    {
                        IMAGELINK = item.IMAGELINK,
                        NAMEPRODUCT = item.NAMEPRODUCT,
                        PRICE = item.PRICE,
                        LIKES = item.LIKES,
                        Id = item.IDPRODUCT,
                    };
                    listpr2.Add(productDto);
                }

                var product3 = context.Products.OrderByDescending(prs => prs.LIKES).Take(4);
                foreach (var item in product3)
                {
                    ProductDto productDto = new ProductDto()
                    {
                        IMAGELINK = item.IMAGELINK,
                        NAMEPRODUCT = item.NAMEPRODUCT,
                        PRICE = item.PRICE,
                        LIKES = item.LIKES,
                        Id = item.IDPRODUCT,
                    };
                    listpr3.Add(productDto);
                }
            }
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.ListProduct = listpr;
            productViewModel.ListProductHot = listpr2;
            productViewModel.ListProductSale = listpr3;

            return View(productViewModel);

        }

        public ActionResult RenderMenu()
        {
            using (var context = new ShopQuanAoEntities())
            {
                var listcategory = context.ProductCategories.Select(ct => new ProductCategoryDto()
                {
                    id = ct.IDCATEGORY,
                    name = ct.NAMECATEGORY,
                }).ToList();
                return PartialView("~/Views/Shared/_MenuBar.cshtml", listcategory);
            }   
        }
        
    }
}
using Entity;
using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        
        public ActionResult Index(int productId)
        {

            ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel();
            using (var context = new ShopQuanAoEntities())
            {
                var product = context.Products.FirstOrDefault(pr => pr.IDPRODUCT == productId);
                productDetailViewModel.NAMEPRODUCT = product.NAMEPRODUCT;
                productDetailViewModel.DESCRIPTIONS = product.DESCRIPTIONS;
                productDetailViewModel.PRICE = product.PRICE;
                productDetailViewModel.STATUSS = product.STATUSS;
                productDetailViewModel.IMAGELINK = product.IMAGELINK;
                productDetailViewModel.SEX = product.SEX;
                productDetailViewModel.LIKES = product.LIKES;
                productDetailViewModel.IDCATEGORY = product.IDCATEGORY;
                productDetailViewModel.IDPRODUCT = productId;

                var imagepr = context.ImageProducts.Where(p => p.IDPRODUCT == productId).ToList();
                productDetailViewModel.ListImage = new List<Image>();
                foreach (var image in imagepr)
                {
                    
                    Image image1 = new Image()
                    {
                        LINK = image.LINK,
                    };
                    productDetailViewModel.ListImage.Add(image1);
                }

                var namecategory = context.ProductCategories.FirstOrDefault(name => name.IDCATEGORY == productDetailViewModel.IDCATEGORY);
                if(namecategory != null)
                {
                    productDetailViewModel.NAMECATEGORY = namecategory.NAMECATEGORY;
                }
                
            }
            return View(productDetailViewModel);
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
                return PartialView("~/Views/Shared/_CategoryMenuRight.cshtml", listcategory);
            }
        }
        public ActionResult RenderSideBar()
        {
            List<ProductDto> listpr = new List<ProductDto>();
            using (var context = new ShopQuanAoEntities())
            {
                var product = context.Products.Take(6);
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
                ProductViewModel productViewModel = new ProductViewModel();
                productViewModel.ListProduct = listpr;
                return PartialView("~/Views/Shared/_SideBarProduct.cshtml", productViewModel);
            }
        }
    }
}
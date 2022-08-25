using Entity;
using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Controllers
{
    public class CartInfoController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

    //    [HttpPost]
    //    public bool AddProduct(CartDto data) 
    //    {
    //        using (var context = new ShopQuanAoEntities())
    //        {
    //            var cartIfo = context.CartInfoes
    //                          .Where(pr => pr.IDPRODUCT == data.IDPRODUCT).FirstOrDefault();
    //            if(cartIfo != null)
    //            {
    //                cartIfo.SOLUONG += data.SOLUONG;
                    
    //                context.SaveChanges();
    //            }
    //            else
    //            {
    //                CartInfo AddProduct = new CartInfo()
    //                {
    //                    IDPRODUCT = data.IDPRODUCT,
    //                    SOLUONG = data.SOLUONG,
    //                };
    //                context.CartInfoes.Add(AddProduct);
    //                context.SaveChanges();
    //            }
                
    //        }
    //        return true;
    //    }
    }
}
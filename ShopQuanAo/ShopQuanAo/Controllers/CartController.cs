using Entity;
using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            List<CartDto> giohang = Session["giohang"] as List<CartDto>;
            


            return View("~/Views/Cart/Cart.cshtml",giohang);

        }
        public RedirectToRouteResult ThemVaoGio(int SanPhamID, int IDUser)
        {
            using (var context = new ShopQuanAoEntities())
            {

                if (Session["giohang"] == null)
                {
                    Session["giohang"] = new List<CartDto>();
                }

                List<CartDto> giohang = Session["giohang"] as List<CartDto>;

                if (giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID) == null)
                {
                    Product sp = context.Products.Find(SanPhamID);
                   
                    CartDto newItem = new CartDto()
                    {
                        SanPhamID = SanPhamID,
                        TenSanPham = sp.NAMEPRODUCT,
                        SoLuong = 1,
                        Hinh = sp.IMAGELINK,
                        DonGia = (int)sp.PRICE

                    };
                    giohang.Add(newItem);

                    Cart cart = new Cart()
                    {
                        IDACC = IDUser,
                        IdProducrt = SanPhamID,
                        SoLuong = 1,
                        DATECREATED = DateTime.Now,
                    };

                    context.Carts.Add(cart);
                    context.SaveChanges();
                    
                }
                else
                {

                    CartDto cardItem = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
                    var item = context.Carts.FirstOrDefault(m => m.IdProducrt == SanPhamID);
                    item.SoLuong++;
                    context.SaveChanges();
                    cardItem.SoLuong++;
                }
            }

            return RedirectToAction("Index", "ProductDetail", new { productId = SanPhamID });
        }
        public RedirectToRouteResult SuaSoLuong(int SanPhamID, int soluongmoi)
        {
            // tìm carditem muon sua
            List<CartDto> giohang = Session["giohang"] as List<CartDto>;

            CartDto itemSua = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
            if (itemSua != null)
            {
                itemSua.SoLuong = soluongmoi;
            }
            return RedirectToAction("Index");

        }
        public RedirectToRouteResult XoaKhoiGio(int SanPhamID)
        {
            List<CartDto> giohang = Session["giohang"] as List<CartDto>;
            using (var context = new ShopQuanAoEntities())
            {
                CartDto itemXoa = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
                if (itemXoa != null)
                {
                    var item = context.Carts.FirstOrDefault(m => m.IdProducrt == SanPhamID);

                    giohang.Remove(itemXoa);
                    context.Carts.Remove(item);
                    context.SaveChanges();
                }
            }   
            return RedirectToAction("Index");
        }
    }

    

}
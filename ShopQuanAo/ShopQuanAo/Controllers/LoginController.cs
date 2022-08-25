using Entity;
using ShopQuanAo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAo.Controllers
{
    public class LoginController : Controller
    {
        

        public ActionResult Login()
        {
            return View();
        }

        // Post: Login

        [HttpPost]
        public ActionResult UserLogin(UserDTO _user)
        {

            using (var context = new ShopQuanAoEntities())
            {
                var data = context.Accounts.FirstOrDefault(u => u.SDT == _user.SDT && u.PASSWORD.Equals(_user.PASSWORD));
                var item = context.Carts.Where(sp => sp.IDACC == data.ID);
                if (data != null)
                {
                    Session["User"] = data;
                    Session["Name"] = data.NAME;
                    Session["SDT"] = data.SDT;
                    Session["Type"] = data.TYPE;
                    Session["idUser"] = (int)data.ID;
                    Session["giohanguser"] = item;
                    if (Session["giohang"] == null)
                    {
                        Session["giohang"] = new List<CartDto>();
                    }

                    List<CartDto> giohang = Session["giohang"] as List<CartDto>;

                    if (Session["giohanguser"] != null)
                    {
                        
                            var data1 = context.Carts.Where(m => m.IDACC == data.ID && m.IdProducrt != null).ToList();
                            foreach (var item1 in data1)
                            {
                                Product sp = context.Products.Find(item1.IdProducrt);

                                CartDto newItem = new CartDto()
                                {
                                    SanPhamID = sp.IDPRODUCT,
                                    TenSanPham = sp.NAMEPRODUCT,
                                    SoLuong = (int)item1.SoLuong,
                                    Hinh = sp.IMAGELINK,
                                    DonGia = (int)sp.PRICE
                                };
                                giohang.Add(newItem);
                            }

                        
                    }
                    var cart = context.Carts.FirstOrDefault(c => c.ID == data.ID && c.STATUSS == 0);
                    if(cart == null)
                    {
                        Cart carts = new Cart();
                        carts.IDACC = data.ID;
                        carts.STATUSS = 0;
                        carts.DATECREATED = DateTime.Now;

                        context.Carts.Add(carts);
                        context.SaveChanges();
                    }
                  
                    return RedirectToAction("Index", "Home", giohang);
                }
                else
                {

                    return View("Login");

                }
            }

            return View("Login");
        }
        
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        //POST: Register
        [HttpPost]
        public ActionResult UserRegister(UserDTO _user)
        {
            using (var context = new ShopQuanAoEntities())
            {
               var data = context.Accounts.FirstOrDefault(u => u.SDT == _user.SDT);
                
                if(data == null)
                {
                    Account account = new Account();
                    account.SDT = _user.SDT;
                    account.PASSWORD = _user.PASSWORD;
                    account.NAME = _user.NAME;
                    

                    context.Accounts.Add(account);
                    context.SaveChanges();
                    
                }
            }
            return View("Login");
        }

    }
}
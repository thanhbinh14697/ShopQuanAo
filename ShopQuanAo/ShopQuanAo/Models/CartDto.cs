﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopQuanAo.Models
{
    public class CartDto
    {
        public string Hinh { get; set; }
        public int SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public int DonGia { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien
        {
            get
            {
                return SoLuong * DonGia;
            }
        }
    }
}
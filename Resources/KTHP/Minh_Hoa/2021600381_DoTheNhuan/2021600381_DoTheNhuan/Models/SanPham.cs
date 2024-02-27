using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2021600381_DoTheNhuan.Models
{
    public class SanPham
    {
        [Key]
        public int MaSP { get; set; }
        public string TenSanPham { get; set; }
        public double DonGia { get; set; }
        public double SoLuongBan { get; set; }
        public double TienBan { get; set; }
    }
}
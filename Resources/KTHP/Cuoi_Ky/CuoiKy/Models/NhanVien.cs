using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CuoiKy.Models
{
    public class NhanVien
    {
        [Key]
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string TrinhDo { get; set; }
        public int Luong { get; set; }
    }
}
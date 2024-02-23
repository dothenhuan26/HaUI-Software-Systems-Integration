using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLLuong.Models
{
    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        public int Ma { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public int HsLuong { get; set; }
        public int MaDonVi { get; set; }
        public virtual DonVi DonVi { get; set; }

    }
}
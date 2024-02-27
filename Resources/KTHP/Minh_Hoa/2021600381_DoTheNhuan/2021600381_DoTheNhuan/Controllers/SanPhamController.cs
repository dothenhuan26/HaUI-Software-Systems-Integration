using _2021600381_DoTheNhuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2021600381_DoTheNhuan.Controllers
{
    public class SanPhamController : ApiController
    {
        QLSanPhamContext db = new QLSanPhamContext();

        [HttpGet]
        public List<SanPham> DanhSachSP()
        {
            return db.SanPhams.ToList();
        }

        [HttpPost]
        public IHttpActionResult ThemSP([FromBody] SanPham sanpham)
        {
            db.SanPhams.Add(sanpham);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult SuaSP([FromBody] SanPham sanpham)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(x => x.MaSP == sanpham.MaSP);
            if (sp != null)
            {
                sp.TenSanPham = sanpham.TenSanPham;
                sp.DonGia = sanpham.DonGia;
                sp.SoLuongBan = sanpham.SoLuongBan;
                sp.TienBan = sanpham.TienBan;
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public IHttpActionResult XoaSP(int id)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(x => x.MaSP == id);
            if (sp != null)
            {
                db.SanPhams.Remove(sp);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}

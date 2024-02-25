using Bai9_10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bai9_10.Controllers
{
    public class NhanVienController : ApiController
    {
        public List<NhanVien> Get()
        {
            QLLuongContext db = new QLLuongContext();
            return db.NhanViens.ToList();
        }
        public IHttpActionResult Post([FromBody] NhanVien nhanVien)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
            }
            return Ok();
        }
        public IHttpActionResult Put([FromBody] NhanVien nhanVien)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                NhanVien nv = db.NhanViens.Find(nhanVien.Ma);
                if (nv != null)
                {
                    nv.HoTen = nhanVien.HoTen;
                    nv.NgaySinh = nhanVien.NgaySinh;
                    nv.GioiTinh = nhanVien.GioiTinh;
                    nv.HsLuong = nhanVien.HsLuong;
                    nv.MaDonVi = nhanVien.MaDonVi;
                    db.SaveChanges();
                }
                else
                    return NotFound();
            }
            return Ok(nhanVien);
        }
        public IHttpActionResult Delete(string ma)
        {
            using (QLLuongContext db = new QLLuongContext())
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(n => n.Ma == ma);
                if (nv != null)
                {
                    db.NhanViens.Remove(nv);
                    db.SaveChanges();
                }
                else
                    return NotFound();
            }
            return Ok();
        }
    }
}

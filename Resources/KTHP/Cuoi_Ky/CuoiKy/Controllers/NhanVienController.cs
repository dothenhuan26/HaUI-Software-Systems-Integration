using CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CuoiKy.Controllers
{
    public class NhanVienController : ApiController
    {

        QLNVContext db = new QLNVContext();

        [HttpGet]
        public List<NhanVien> Show()
        {

            return db.NhanViens.ToList();
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] NhanVien nhanvien)
        {
            db.NhanViens.Add(nhanvien);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] NhanVien nhanvien)
        {
            NhanVien nv = db.NhanViens.FirstOrDefault(x => x.MaNV == nhanvien.MaNV);
            if (nv != null)
            {
                nv.HoTen = nhanvien.HoTen;
                nv.TrinhDo = nhanvien.TrinhDo;
                nv.Luong = nhanvien.Luong;
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            NhanVien nv = db.NhanViens.Find(id);
            if (nv != null)
            {
                db.NhanViens.Remove(nv);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

    }
}

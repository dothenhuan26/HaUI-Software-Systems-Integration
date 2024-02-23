using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Example.Controllers
{
    public class SanPhamController : ApiController
    {
        [HttpGet]
        public List<SanPham> LayToanBoSanPham()
        {
            CSDLTestDataContext context = new CSDLTestDataContext();

            List<SanPham> dsSP = context.SanPhams.ToList();

            foreach (SanPham sp in dsSP)
            {
                sp.DanhMuc = null;
            }

            return dsSP;

        }

        [HttpGet]
        public SanPham ChiTietSanPham(int id)
        {
            CSDLTestDataContext context = new CSDLTestDataContext();
            SanPham sp = context.SanPhams.First(x => x.Ma == id);
            if (sp != null)
            {
                sp.DanhMuc = null;
            }
            return sp;
        }

        [HttpGet]
        public List<SanPham> DanhSachSanPhamTheoDanhMuc(int madm)
        {
            CSDLTestDataContext context = new CSDLTestDataContext();
            List<SanPham> dsSP = context.SanPhams.Where(x => x.MaDanhMuc == madm).ToList();

            foreach (SanPham sp in dsSP)
            {
                sp.DanhMuc = null;
            }

            return dsSP;
        }

        [HttpGet]
        public List<SanPham> TimDanhSachSanPhamCoGiaTriTrongDoanAB(int a, int b)
        {
            CSDLTestDataContext context = new CSDLTestDataContext();
            List<SanPham> dsSP = context.SanPhams.Where(x => x.DonGia >= a && x.DonGia <= b).ToList();
            foreach (SanPham sp in dsSP)
            {
                sp.DanhMuc = null;
            }

            return dsSP;


        }




    }
}

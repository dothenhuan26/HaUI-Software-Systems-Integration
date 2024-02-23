using QLLuong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLLuong.Controllers
{
    public class NhanVienController : ApiController
    {

        QLLuongContext context = new QLLuongContext();


        [HttpGet]
        public List<NhanVien> Show()
        {
            List<NhanVien> li = context.NhanViens.ToList();

            foreach(NhanVien nv in li)
            {
                nv.DonVi = null;
            }

            return li;
        }



    }
}

using QLLuong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLLuong.Controllers
{
    public class DonViController : ApiController
    {
        QLLuongContext context = new QLLuongContext();
        [HttpGet]
        public List<DonVi> Show()
        {
            List<DonVi> li = context.DonVis.ToList();

            foreach (DonVi dv in li)
            {
                dv.NhanViens.Clear();
            }

            return li;
        }


    }
}

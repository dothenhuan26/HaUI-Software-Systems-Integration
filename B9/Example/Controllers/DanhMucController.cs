using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Example.Controllers
{
    public class DanhMucController : ApiController
    {
        CSDLTestDataContext context = new CSDLTestDataContext();
        [HttpGet]
        public List<DanhMuc> LayToanBoDanhMuc()
        {
            List<DanhMuc> dsDM = context.DanhMucs.ToList();

            foreach (DanhMuc dm in dsDM)
            {
                dm.SanPhams.Clear();
            }

            return dsDM;
        }

        [HttpGet]
        public DanhMuc ChiTietDanhMuc(int id)
        {
            DanhMuc dm = context.DanhMucs.FirstOrDefault(x => x.MaDanhMuc == id);
            if (dm != null)
            {
                dm.SanPhams.Clear();
            }
            return dm;
        }

        [HttpGet]
        public bool LuuDanhMuc(int madm, string tendm)
        {
            try
            {
                DanhMuc dm = new DanhMuc();
                dm.MaDanhMuc = madm;
                dm.TenDanhMuc = tendm;
                context.DanhMucs.InsertOnSubmit(dm);
                context.SubmitChanges();
                return true;
            }
            catch { }
            return false;
        }

        [HttpPut]
        public bool SuaDanhMuc(int madm, string tendm)
        {
            DanhMuc dm = context.DanhMucs.FirstOrDefault(x => x.MaDanhMuc == madm);
            if (dm != null)
            {
                dm.TenDanhMuc = tendm;
                context.SubmitChanges();
                return true;
            }
            return false;
        }



    }
}

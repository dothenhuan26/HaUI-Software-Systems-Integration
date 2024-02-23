using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Example.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public List<Employee> Show()
        {
            using (HRMContext db = new HRMContext())
            {
                return db.Employees.ToList();
            }
        }

        public IHttpActionResult Post([FromBody] Employee employee)
        {
            using (HRMContext db = new HRMContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            return Ok();


        }



    }
}

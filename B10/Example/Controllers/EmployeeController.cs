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

        [HttpPost]
        public IHttpActionResult Create([FromBody] Employee employee)
        {
            using (HRMContext db = new HRMContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            return Ok();
        }

        public Employee Detail(int id)
        {
            using (HRMContext db = new HRMContext())
            {
                Employee ee = db.Employees.FirstOrDefault(x => x.ID == id);
                if (ee != null)
                {
                    return ee;
                }
                return null;
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Employee employee)
        {
            using (HRMContext db = new HRMContext())
            {
                Employee ee = db.Employees.FirstOrDefault(x => x.ID == employee.ID);

                if (ee != null)
                {
                    ee.Code = employee.Code;
                    ee.BirthDate = employee.BirthDate;
                    ee.FullName = employee.FullName;
                    ee.Gender = employee.Gender;
                    db.SaveChanges();
                    return Ok();
                }
            }
            return NotFound();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            using (HRMContext db = new HRMContext())
            {
                Employee ee = db.Employees.FirstOrDefault(x => x.ID == id);

                if (ee != null)
                {
                    db.Employees.Remove(ee);
                    db.SaveChanges();
                    return Ok();
                }
            }
            return NotFound();
        }



    }
}

using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
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
        public IHttpActionResult Put([FromBody] Employee employee)
        {
            using (HRMContext db = new HRMContext())
            {
                Employee employee1 = db.Employees.Find(employee.ID);
                if (employee1 != null)
                {
                    employee1.Code = employee.Code;
                    employee1.FullName = employee.FullName;
                    employee1.BirthDate = employee.BirthDate;
                    employee1.Gender = employee.Gender;
                    db.SaveChanges();
                }
                else
                    return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult Delete(int iD)
        {
            using (HRMContext db = new HRMContext())
            {
                Employee employee1 = db.Employees.Find(iD);
                if (employee1 != null)
                {
                    db.Employees.Remove(employee1);
                    db.SaveChanges();
                }
                else
                    return NotFound();
            }
            return Ok();
        }
    }
}

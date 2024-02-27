using _2021600381_DoTheNhuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2021600381_DoTheNhuan.Controllers
{
    public class EmployeeController : ApiController
    {

        HRMContext db = new HRMContext();

        [HttpGet]
        public List<Employee> Show()
        {
            return db.Employees.ToList();
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Employee employee)
        {
            Employee emp = db.Employees.FirstOrDefault(x => x.ID == employee.ID);
            if (emp != null)
            {
                emp.FullName = employee.FullName;
                emp.BirthDate = employee.BirthDate;
                emp.Gender = employee.Gender;
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Employee emp = db.Employees.FirstOrDefault(x => x.ID == id);
            if (emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }



    }
}

using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Example.Controllers
{
    public class EmployeesController : ApiController
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
            Employee emp = db.Employees.Find(employee.ID);
            if (emp != null)
            {
                emp.Code = employee.Code;
                emp.FullName = employee.FullName;
                emp.BirthDate = employee.BirthDate;
                emp.Gender = employee.Gender;
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Example.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }


    }
}
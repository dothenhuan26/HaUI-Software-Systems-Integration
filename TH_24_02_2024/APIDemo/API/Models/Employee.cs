using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Employee
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
    }
}
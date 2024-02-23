using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Example.Models
{
    public class HRMContext : DbContext
    {
        public HRMContext():base("Data Source=nhuandt\\MSSQLSERVER01;Initial Catalog=HRM;Integrated Security=True")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Employee> Employees { get; set; }


    }
}
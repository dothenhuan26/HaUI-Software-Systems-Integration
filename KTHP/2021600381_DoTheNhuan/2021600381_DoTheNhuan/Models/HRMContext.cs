using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace _2021600381_DoTheNhuan.Models
{
    public class HRMContext : DbContext
    {

        public HRMContext():base("Data Source=nhuandt\\MSSQLSERVER01;Initial Catalog=HRM;User ID=hrm;Password=123456") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
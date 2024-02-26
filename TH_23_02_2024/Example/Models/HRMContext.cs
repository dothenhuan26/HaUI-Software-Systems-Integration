using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Example.Models
{
    public class HRMContext : DbContext
    {
        public HRMContext() : base("Data Source=nhuandt\\MSSQLSERVER01;Initial Catalog=HRM;User iD=abc;Password=123") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
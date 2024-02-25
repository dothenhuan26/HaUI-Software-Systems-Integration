using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class HRMContext : DbContext
    {
        public HRMContext() : base("Data Source=(local);Initial Catalog=HRM;User ID=abc;Password=123456") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
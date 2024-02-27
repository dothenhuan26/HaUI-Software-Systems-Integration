using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CuoiKy.Models
{
    public class QLNVContext : DbContext
    {

        public QLNVContext() : base("Data Source=nhuandt\\MSSQLSERVER01;Initial Catalog=QLNV;User ID=cuoiky;Password=123456") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<NhanVien> NhanViens { get; set; }

    }
}
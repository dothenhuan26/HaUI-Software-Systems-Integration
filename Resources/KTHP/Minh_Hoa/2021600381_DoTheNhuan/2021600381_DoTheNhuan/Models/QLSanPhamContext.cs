using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace _2021600381_DoTheNhuan.Models
{
    public class QLSanPhamContext : DbContext
    {
        public QLSanPhamContext() : base("Data Source=nhuandt\\MSSQLSERVER01;Initial Catalog=QuanLySanPhamDB;User ID=qlsp;Password=123456") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<SanPham> SanPhams { get; set; }
    }
}
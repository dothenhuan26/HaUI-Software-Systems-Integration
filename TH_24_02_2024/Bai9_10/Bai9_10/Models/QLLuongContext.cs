using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Bai9_10.Models
{
    public class QLLuongContext : DbContext
    {
        public QLLuongContext()
            : base("Data Source=(local);Initial Catalog=QLLuong;user id=sa;password=123456")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
    }
}
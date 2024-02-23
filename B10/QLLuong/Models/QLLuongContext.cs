using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace QLLuong.Models
{
    public class QLLuongContext : DbContext
    {
        public QLLuongContext() : base("Data Source=nhuandt\\MSSQLSERVER01;Initial Catalog=QLLuong;Integrated Security=True")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<DonVi>()
                .HasMany<NhanVien>(e => e.NhanViens)
                .WithRequired(e => e.DonVi)
                .HasForeignKey<int>(s=>s.MaDonVi)
                .WillCascadeOnDelete(false);
        }

        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }






    }
}
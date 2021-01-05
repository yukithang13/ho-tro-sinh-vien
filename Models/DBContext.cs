using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HoTroSinhVien.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext1")
        {
        }

        public virtual DbSet<DangNhap> DangNhaps { get; set; }
        public virtual DbSet<DaoDuc> DaoDucs { get; set; }
        public virtual DbSet<HocTap> HocTaps { get; set; }
        public virtual DbSet<HoiNhap> HoiNhaps { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<TheLuc> TheLucs { get; set; }
        public virtual DbSet<TinhNguyen> TinhNguyens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DangNhap>()
                .Property(e => e.TaiKhoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DaoDuc>()
                .HasMany(e => e.SinhViens)
                .WithRequired(e => e.DaoDuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HocTap>()
                .HasMany(e => e.SinhViens)
                .WithRequired(e => e.HocTap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoiNhap>()
                .HasMany(e => e.SinhViens)
                .WithRequired(e => e.HoiNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MSSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TheLuc>()
                .HasMany(e => e.SinhViens)
                .WithRequired(e => e.TheLuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TinhNguyen>()
                .HasMany(e => e.SinhViens)
                .WithRequired(e => e.TinhNguyen)
                .WillCascadeOnDelete(false);
        }
    }
}

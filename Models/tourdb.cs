using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TOUR.Models
{
    public partial class tourdb : DbContext
    {
        public tourdb()
            : base("name=tourdb")
        {
        }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<ChuDeBaiViet> ChuDeBaiViets { get; set; }
        public virtual DbSet<DongTour> DongTours { get; set; }
        public virtual DbSet<DonHangPheDuyet> DonHangPheDuyets { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<PhanHoiLienHe> PhanHoiLienHes { get; set; }
        public virtual DbSet<ThongTinTheoTourKhach> ThongTinTheoTourKhaches { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiViet>()
                .Property(e => e.anhBaiViet)
                .IsUnicode(false);

            modelBuilder.Entity<BaiViet>()
                .HasMany(e => e.PhanHoiLienHes)
                .WithOptional(e => e.BaiViet)
                .HasForeignKey(e => e.idBaiViet);

            modelBuilder.Entity<ChuDeBaiViet>()
                .HasMany(e => e.BaiViets)
                .WithRequired(e => e.ChuDeBaiViet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DongTour>()
                .HasMany(e => e.Tours)
                .WithRequired(e => e.DongTour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.sdtKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.sdtCty)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.emailCty)
                .IsUnicode(false);

            modelBuilder.Entity<LienHe>()
                .Property(e => e.facebookCty)
                .IsUnicode(false);

            modelBuilder.Entity<PhanHoiLienHe>()
                .Property(e => e.sdtKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<PhanHoiLienHe>()
                .Property(e => e.emailKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinTheoTourKhach>()
                .Property(e => e.sdtKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .Property(e => e.anhTour)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .Property(e => e.anhChiTietTour)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .HasMany(e => e.ThongTinTheoTourKhaches)
                .WithRequired(e => e.Tour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.anhUser)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}

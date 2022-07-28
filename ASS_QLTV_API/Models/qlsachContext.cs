using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASS_QLTV_API.Models
{
    public partial class qlsachContext : DbContext
    {
        public qlsachContext()
        {
        }

        public qlsachContext(DbContextOptions<qlsachContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ctpm> Ctpms { get; set; }
        public virtual DbSet<Docgium> Docgia { get; set; }
        public virtual DbSet<Phieumuon> Phieumuons { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=Kanchou\\SQLExpress;Database=qlsach;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Ctpm>(entity =>
            {
                entity.HasKey(e => e.MaCtpm)
                    .HasName("PK_ctpm_MaPM");

                entity.ToTable("ctpm", "qlsach");

                entity.HasIndex(e => e.MaSach, "MaSach");

                entity.HasIndex(e => e.User, "User");

                entity.Property(e => e.MaCtpm)
                    .HasMaxLength(10)
                    .HasColumnName("MaCTPM")
                    .IsFixedLength(true);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.MaPm)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MaPM");

                entity.Property(e => e.MaSach)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.NgayTra).HasColumnType("date");

                entity.Property(e => e.User).HasMaxLength(10);

                entity.HasOne(d => d.MaPmNavigation)
                    .WithMany(p => p.Ctpms)
                    .HasForeignKey(d => d.MaPm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ctpm_phieumuon");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.Ctpms)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ctpm$ctpm_ibfk_3");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Ctpms)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("ctpm$ctpm_ibfk_1");
            });

            modelBuilder.Entity<Docgium>(entity =>
            {
                entity.HasKey(e => e.MaDg)
                    .HasName("PK_docgia_MaDG");

                entity.ToTable("docgia", "qlsach");

                entity.Property(e => e.MaDg)
                    .HasMaxLength(10)
                    .HasColumnName("MaDG");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GioiTinh)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenDg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TenDG");
            });

            modelBuilder.Entity<Phieumuon>(entity =>
            {
                entity.HasKey(e => e.MaPm)
                    .HasName("PK_phieumuon_MaPM");

                entity.ToTable("phieumuon", "qlsach");

                entity.HasIndex(e => e.MaDg, "fk_phieumuon_MaDG");

                entity.HasIndex(e => e.User, "fk_phieumuon_User");

                entity.Property(e => e.MaPm)
                    .HasMaxLength(10)
                    .HasColumnName("MaPM");

                entity.Property(e => e.MaDg)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MaDG");

                entity.Property(e => e.NgayHenTra).HasColumnType("date");

                entity.Property(e => e.NgayMuon).HasColumnType("date");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.MaDgNavigation)
                    .WithMany(p => p.Phieumuons)
                    .HasForeignKey(d => d.MaDg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("phieumuon$fk_phieumuon_MaDG");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Phieumuons)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("phieumuon$fk_phieumuon_User");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach)
                    .HasName("PK_sach_MaSach");

                entity.ToTable("sach", "qlsach");

                entity.Property(e => e.MaSach).HasMaxLength(10);

                entity.Property(e => e.ImageUrl).HasMaxLength(500);

                entity.Property(e => e.MieuTa).HasMaxLength(2500);

                entity.Property(e => e.NhaXb)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("NhaXB");

                entity.Property(e => e.TenSach)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.TenTg)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("TenTG");

                entity.Property(e => e.TheLoai)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.User)
                    .HasName("PK_taikhoan_User");

                entity.ToTable("taikhoan", "qlsach");

                entity.Property(e => e.User).HasMaxLength(10);

                entity.Property(e => e.Cmnd)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("CMND");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenNd)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TenND");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

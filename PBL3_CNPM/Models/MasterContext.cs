using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PBL3_CNPM.Models;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chucvu> Chucvus { get; set; }

    public virtual DbSet<Congviec> Congviecs { get; set; }

    public virtual DbSet<CongviecNv> CongviecNvs { get; set; }

    public virtual DbSet<Hoso> Hosos { get; set; }

    public virtual DbSet<Luong> Luongs { get; set; }

    public virtual DbSet<LuongNv> LuongNvs { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Phanquyen> Phanquyens { get; set; }

    public virtual DbSet<Phongban> Phongbans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SP2HFDB;Initial Catalog=QUANLYNHANVIENKHACHSAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chucvu>(entity =>
        {
            entity.HasKey(e => e.MaChucVu).HasName("PK_Luong");

            entity.ToTable("Chucvu");

            entity.Property(e => e.MaChucVu)
                .HasMaxLength(10)
                .HasColumnName("Ma ChucVu");
            entity.Property(e => e.ChucVu)
                .HasMaxLength(50)
                .HasColumnName("Chuc Vu");
        });

        modelBuilder.Entity<Congviec>(entity =>
        {
            entity.HasKey(e => e.MaCongViec).HasName("PK_Congviec_1");

            entity.ToTable("Congviec");

            entity.Property(e => e.MaCongViec)
                .HasMaxLength(10)
                .HasColumnName("Ma CongViec");
            entity.Property(e => e.CaLam).HasColumnName("Ca Lam");
            entity.Property(e => e.ChiTietCongViec)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Chi Tiet Cong Viec");
        });

        modelBuilder.Entity<CongviecNv>(entity =>
        {
            entity.HasKey(e => e.MaCongViec).HasName("PK_Congviec");

            entity.ToTable("CongviecNV");

            entity.Property(e => e.MaCongViec)
                .HasMaxLength(10)
                .HasColumnName("Ma CongViec");
            entity.Property(e => e.ChamCong).HasColumnName("Cham Cong");
            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .HasColumnName("Ma NV");
            entity.Property(e => e.NgayLam)
                .HasColumnType("date")
                .HasColumnName("Ngay Lam");
            entity.Property(e => e.NghiPhep).HasColumnName("Nghi Phep");

            entity.HasOne(d => d.MaCongViecNavigation).WithOne(p => p.CongviecNv)
                .HasForeignKey<CongviecNv>(d => d.MaCongViec)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CongviecNV_Congviec");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.CongviecNvs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK_CongviecNV_Nhanvien");
        });

        modelBuilder.Entity<Hoso>(entity =>
        {
            entity.HasKey(e => e.MaHoSo);

            entity.ToTable("Hoso");

            entity.Property(e => e.MaHoSo)
                .HasMaxLength(10)
                .HasColumnName("Ma HoSo");
            entity.Property(e => e.KinhNghiem).HasColumnName("Kinh nghiem");
            entity.Property(e => e.MaChucVu)
                .HasMaxLength(10)
                .HasColumnName("Ma ChucVu");
            entity.Property(e => e.MaMv)
                .HasMaxLength(10)
                .HasColumnName("Ma MV");
            entity.Property(e => e.MaPhongBan)
                .HasMaxLength(10)
                .HasColumnName("Ma PhongBan");
            entity.Property(e => e.TrinhDo).HasColumnName("Trinh do");

            entity.HasOne(d => d.MaChucVuNavigation).WithMany(p => p.Hosos)
                .HasForeignKey(d => d.MaChucVu)
                .HasConstraintName("FK_Hoso_Luong");

            entity.HasOne(d => d.MaMvNavigation).WithMany(p => p.Hosos)
                .HasForeignKey(d => d.MaMv)
                .HasConstraintName("FK_Hoso_Nhanvien");

            entity.HasOne(d => d.MaPhongBanNavigation).WithMany(p => p.Hosos)
                .HasForeignKey(d => d.MaPhongBan)
                .HasConstraintName("FK_Hoso_Phongban");
        });

        modelBuilder.Entity<Luong>(entity =>
        {
            entity.HasKey(e => e.MaLuong).HasName("PK_Luong_1");

            entity.ToTable("Luong");

            entity.Property(e => e.MaLuong)
                .HasMaxLength(10)
                .HasColumnName("Ma Luong");
            entity.Property(e => e.LuongCoBan)
                .HasColumnType("decimal(12, 3)")
                .HasColumnName("Luong Co Ban");
            entity.Property(e => e.PhuCap)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("Phu Cap");
            entity.Property(e => e.TenMaLuong)
                .HasMaxLength(50)
                .HasColumnName("Ten Ma Luong");
        });

        modelBuilder.Entity<LuongNv>(entity =>
        {
            entity.HasKey(e => e.MaLuong).HasName("PK_Bangluong");

            entity.ToTable("LuongNV");

            entity.Property(e => e.MaLuong)
                .HasMaxLength(10)
                .HasColumnName("Ma Luong");
            entity.Property(e => e.LuongTong)
                .HasColumnType("decimal(12, 0)")
                .HasColumnName("Luong Tong");
            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .HasColumnName("Ma NV");
            entity.Property(e => e.NgayCong).HasColumnName("Ngay cong");
            entity.Property(e => e.Phat).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Thuong).HasColumnType("decimal(10, 3)");

            entity.HasOne(d => d.MaLuongNavigation).WithOne(p => p.LuongNv)
                .HasForeignKey<LuongNv>(d => d.MaLuong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LuongNV_Luong");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.LuongNvs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK_LuongNV_Nhanvien");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.MaNv);

            entity.ToTable("Nhanvien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .HasColumnName("Ma NV");
            entity.Property(e => e.Cccd)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("CCCD");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(50)
                .HasColumnName("Dia chi");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasColumnName("Gioi Tinh");
            entity.Property(e => e.HinhAnh).HasColumnName("Hinh anh");
            entity.Property(e => e.MaBaoHiem)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Ma BaoHiem");
            entity.Property(e => e.MaPhanQuyen)
                .HasMaxLength(10)
                .HasColumnName("Ma PhanQuyen");
            entity.Property(e => e.MaPhongBan)
                .HasMaxLength(10)
                .HasColumnName("Ma PhongBan");
            entity.Property(e => e.NgaySinh)
                .HasColumnType("date")
                .HasColumnName("Ngay Sinh");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("So Dien Thoai");
            entity.Property(e => e.TaiKhoanNganHang)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Tai Khoan Ngan Hang");
            entity.Property(e => e.TenNganHang)
                .HasMaxLength(50)
                .HasColumnName("Ten Ngan Hang");
            entity.Property(e => e.TenNhanVien)
                .HasMaxLength(50)
                .HasColumnName("Ten Nhan Vien");

            entity.HasOne(d => d.MaPhanQuyenNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.MaPhanQuyen)
                .HasConstraintName("FK_Nhanvien_Phanquyen");
        });

        modelBuilder.Entity<Phanquyen>(entity =>
        {
            entity.HasKey(e => e.MaPhanQuyen);

            entity.ToTable("Phanquyen");

            entity.Property(e => e.MaPhanQuyen)
                .HasMaxLength(10)
                .HasColumnName("Ma PhanQuyen");
            entity.Property(e => e.PhanQuyen)
                .HasMaxLength(50)
                .HasColumnName("Phan Quyen");
        });

        modelBuilder.Entity<Phongban>(entity =>
        {
            entity.HasKey(e => e.MaPhongBan);

            entity.ToTable("Phongban");

            entity.Property(e => e.MaPhongBan)
                .HasMaxLength(10)
                .HasColumnName("Ma PhongBan");
            entity.Property(e => e.MaTruongPhong).HasColumnName("Ma TruongPhong");
            entity.Property(e => e.TenPhongBan)
                .HasMaxLength(50)
                .HasColumnName("Ten PhongBan");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

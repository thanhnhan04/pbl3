using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class Nhanvien
{
    public string MaNv { get; set; } = null!;

    public string? TenNhanVien { get; set; }

    public DateTime NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? Cccd { get; set; }

    public string? MaBaoHiem { get; set; }

    public string? TaiKhoanNganHang { get; set; }

    public string? TenNganHang { get; set; }

    public string? MaPhongBan { get; set; }

    public string? Password { get; set; }

    public string? MaPhanQuyen { get; set; }

    public string? MaChucVu { get; set; }

    public string? TrinhDo { get; set; }

    public string? KinhNghiem { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<CongviecNv> CongviecNvs { get; set; } = new List<CongviecNv>();

    public virtual ICollection<LuongNv> LuongNvs { get; set; } = new List<LuongNv>();

    public virtual Chucvu? MaChucVuNavigation { get; set; }

    public virtual Phanquyen? MaPhanQuyenNavigation { get; set; }

    public virtual Phongban? MaPhongBanNavigation { get; set; }
}

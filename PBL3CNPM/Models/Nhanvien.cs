using System;
using System.Collections.Generic;

namespace PBL3CNPM.Models;

public partial class Nhanvien
{
    public string MaNv { get; set; } = null!;

    public string? TenNhanVien { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public byte[]? HinhAnh { get; set; }

    public string? Email { get; set; }

    public string? Cccd { get; set; }

    public string? MaBaoHiem { get; set; }

    public string? TaiKhoanNganHang { get; set; }

    public string? TenNganHang { get; set; }

    public string? MaPhongBan { get; set; }

    public string? Password { get; set; }

    public string? MaPhanQuyen { get; set; }

    public virtual ICollection<CongviecNv> CongviecNvs { get; set; } = new List<CongviecNv>();

    public virtual ICollection<Hoso> Hosos { get; set; } = new List<Hoso>();

    public virtual ICollection<LuongNv> LuongNvs { get; set; } = new List<LuongNv>();

    public virtual Phanquyen? MaPhanQuyenNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class Hoso
{
    public string MaHoSo { get; set; } = null!;

    public string? MaMv { get; set; }

    public string? MaChucVu { get; set; }

    public string? MaPhongBan { get; set; }

    public string? TrinhDo { get; set; }

    public string? KinhNghiem { get; set; }

    public virtual Chucvu? MaChucVuNavigation { get; set; }

    public virtual Nhanvien? MaMvNavigation { get; set; }

    public virtual Phongban? MaPhongBanNavigation { get; set; }
}

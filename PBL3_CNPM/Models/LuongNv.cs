using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class LuongNv
{
    public string MaLuong { get; set; } = null!;

    public string? MaNv { get; set; }

    public int? Thang { get; set; }

    public int? NgayCong { get; set; }

    public decimal? Thuong { get; set; }

    public decimal? Phat { get; set; }
    public decimal? Luongcoban { get; set; }
    public decimal? LuongTong { get; set; }

    public virtual Luong MaLuongNavigation { get; set; } = null!;

    public virtual Nhanvien? MaNvNavigation { get; set; }
}

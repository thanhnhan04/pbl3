using System;
using System.Collections.Generic;

namespace PBL3CNPM.Models;

public partial class LuongNv
{
    public string MaLuong { get; set; } = null!;

    public string? MaNv { get; set; }

    public int? Thang { get; set; }

    public int? NgayCong { get; set; }

    public decimal? Thưởng { get; set; }

    public decimal? Phạt { get; set; }

    public decimal? LuongTong { get; set; }

    public virtual Luong MaLuongNavigation { get; set; } = null!;

    public virtual Nhanvien? MaNvNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace PBL3CNPM.Models;

public partial class Luong
{
    public string MaLuong { get; set; } = null!;

    public string? TenMaLuong { get; set; }

    public decimal? LuongCoBan { get; set; }

    public decimal? PhuCap { get; set; }

    public virtual LuongNv? LuongNv { get; set; }
}

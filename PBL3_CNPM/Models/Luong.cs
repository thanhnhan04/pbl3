using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class Luong
{
    public string MaLuong { get; set; } = null!;

    public string? TenMaLuong { get; set; }

    public Decimal? LuongCoBan { get; set; }

    public Decimal? PhuCap { get; set; }

    public virtual LuongNv? LuongNv { get; set; }
}

using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class Luong
{
    public int MaLuong { get; set; }

    public string? TenMaLuong { get; set; }

    public decimal? LuongCoBan { get; set; }

    public decimal? PhuCap { get; set; }

    public virtual ICollection<LuongNv> LuongNvs { get; set; } = new List<LuongNv>();
}

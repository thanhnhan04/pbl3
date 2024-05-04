using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class Phongban
{
    public string MaPhongBan { get; set; } = null!;

    public string? TenPhongBan { get; set; }

    public int? MaTruongPhong { get; set; }

    public virtual ICollection<Hoso> Hosos { get; set; } = new List<Hoso>();
}

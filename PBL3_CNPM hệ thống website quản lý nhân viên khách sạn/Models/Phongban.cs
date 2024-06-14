using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class Phongban
{
    public string MaPhongBan { get; set; } = null!;

    public string? TenPhongBan { get; set; }

    public string? MaTruongPhong { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}

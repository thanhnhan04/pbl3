using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class Chucvu
{
    public string MaChucVu { get; set; } = null!;

    public string? ChucVu { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}

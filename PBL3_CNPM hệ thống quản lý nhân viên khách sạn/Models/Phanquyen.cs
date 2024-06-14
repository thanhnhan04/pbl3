using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class Phanquyen
{
    public string MaPhanQuyen { get; set; } = null!;

    public string? PhanQuyen { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}

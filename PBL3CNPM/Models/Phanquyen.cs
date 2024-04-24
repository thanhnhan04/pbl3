using System;
using System.Collections.Generic;

namespace PBL3CNPM.Models;

public partial class Phanquyen
{
    public string MãPhânQuyền { get; set; } = null!;

    public string? PhânQuyền { get; set; }

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}

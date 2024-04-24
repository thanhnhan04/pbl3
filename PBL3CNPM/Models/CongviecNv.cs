using System;
using System.Collections.Generic;

namespace PBL3CNPM.Models;

public partial class CongviecNv
{
    public string MaCongViec { get; set; } = null!;

    public string? MaNv { get; set; }

    public DateOnly? NgayLam { get; set; }

    public bool? ChamCong { get; set; }

    public int? NghiPhep { get; set; }

    public virtual Congviec MaCongViecNavigation { get; set; } = null!;

    public virtual Nhanvien? MaNvNavigation { get; set; }
}

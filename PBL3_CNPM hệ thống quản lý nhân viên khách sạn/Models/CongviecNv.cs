using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class CongviecNv
{
    public int MaCongViecNv { get; set; }

    public int MaCongViec { get; set; }

    public string? MaNv { get; set; }

    public DateTime NgayLam { get; set; }

    public virtual Congviec MaCongViecNavigation { get; set; } = null!;

    public virtual Nhanvien? MaNvNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class Congviec
{
    public string MaCongViec { get; set; } = null!;

    public string? ChiTietCongViec { get; set; }

    public TimeOnly? CaLam { get; set; }

    public virtual CongviecNv? CongviecNv { get; set; }
}

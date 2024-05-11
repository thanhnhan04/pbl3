using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class Congviec
{
    public int? MaCongViec { get; set; } 

    public string? ChiTietCongViec { get; set; }

    public string? CaLam { get; set; }

    public virtual CongviecNv? CongviecNv { get; set; }
}

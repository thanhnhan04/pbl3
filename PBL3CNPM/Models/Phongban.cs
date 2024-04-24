using System;
using System.Collections.Generic;

namespace PBL3CNPM.Models;

public partial class Phongban
{
    public string MãPhòngBan { get; set; } = null!;

    public string? TênPhòngBan { get; set; }

    public int? MãTrưởngPhòng { get; set; }

    public virtual ICollection<Hoso> Hosos { get; set; } = new List<Hoso>();
}

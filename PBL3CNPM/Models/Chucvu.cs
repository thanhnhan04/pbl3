using System;
using System.Collections.Generic;

namespace PBL3CNPM.Models;

public partial class Chucvu
{
    public string MãChứcVụ { get; set; } = null!;

    public string? ChứcVụ { get; set; }

    public virtual ICollection<Hoso> Hosos { get; set; } = new List<Hoso>();
}

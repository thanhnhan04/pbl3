﻿using System;
using System.Collections.Generic;

namespace PBL3_CNPM.Models;

public partial class LuongNv
{
    public int MaLuongNv { get; set; }

    public int? MaLuong { get; set; }

    public string? MaNv { get; set; }

    public DateTime? Thang { get; set; }

    public int? NgayCong { get; set; }

    public decimal? Thuong { get; set; }

    public decimal? Phat { get; set; }

    public decimal? LuongTong { get; set; }

    public virtual Luong? MaLuongNavigation { get; set; }

    public virtual Nhanvien? MaNvNavigation { get; set; }
}

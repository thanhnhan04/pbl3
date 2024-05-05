namespace PBL3_CNPM.Models
{
    public class LuongNvCombined
    {
        public Luong Luong { get; set; }
        public LuongNv LuongNv { get; set; }
        public string MaLuong { get; set; } = null!;

        public string? MaNv { get; set; }

        public int? Thang { get; set; }

        public int? NgayCong { get; set; }

        public decimal? Thuong { get; set; }

        public decimal? Phat { get; set; }
       
        public decimal? LuongTong { get; set; }

        public decimal? LuongCoBan { get; set; }

        public decimal? PhuCap { get; set; }

        


    }
}

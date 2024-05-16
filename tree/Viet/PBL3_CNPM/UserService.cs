using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PBL3_CNPM.Models;
using PBL3_CNPM;

namespace PBL3_CNPM
{
    public class UserService
    {
        private string _connectionString;

        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public LuongNv GetLuongNv(string userId)
        {
            LuongNv luongNv = null;
            DataProvider dataProvider = new DataProvider(); 

            string query = "SELECT LNV.[Ma Luong], L.[Luong Co Ban], LNV.Thang, LNV.[Ngay Cong], L.[Phu Cap], LNV.Thuong, LNV.Phat, LNV.[Luong Tong] " +
                           "FROM LuongNV AS LNV " +
                           "INNER JOIN Luong AS L ON L.[Ma Luong] = LNV.[Ma Luong] " +
                           "WHERE LNV.[Ma NV] = @MaNV";

            SqlDataReader reader = dataProvider.ExecuteReader(query, userId);

            if (reader.Read())
            {
                luongNv = new LuongNv();

                luongNv.MaLuong = reader["Ma Luong"].ToString();
                luongNv.Luongcoban = Convert.ToDecimal(reader["Luong Co Ban"]);
                luongNv.Thang = Convert.ToInt32(reader["Thang"]);
                luongNv.NgayCong = Convert.ToInt32(reader["Ngay Cong"]);
                luongNv.Phucap = Convert.ToDecimal(reader["Phu Cap"]);
                luongNv.Thuong = Convert.ToDecimal(reader["Thuong"]);
                luongNv.Phat = Convert.ToDecimal(reader["Phat"]);
                luongNv.LuongTong = Convert.ToDecimal(reader["Luong Tong"]);
            }
            dataProvider.Dispose();
            return luongNv;
        }


    }
}




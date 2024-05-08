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

        public Nhanvien GetUserById(string IdUser)
        {
            Nhanvien user = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Nhanvien WHERE [Ma NV] = @MaNV";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@MaNV", IdUser);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user = new Nhanvien();
                    user.MaNv = reader["Ma NV"].ToString();
                    user.TenNhanVien = reader["Ten Nhan Vien"].ToString();
                    user.GioiTinh = reader["Gioi Tinh"].ToString();
                    user.DiaChi = reader["Dia Chi"].ToString();
                    user.Cccd = reader["CCCD"].ToString();
                    user.SoDienThoai = reader["So Dien Thoai"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.TenNganHang = reader["Ten Ngan Hang"].ToString();
                    user.TaiKhoanNganHang = reader["Tai Khoan Ngan Hang"].ToString();
                    user.NgaySinh = Convert.ToDateTime(reader["Ngay Sinh"].ToString());
                }
            }
            return user;
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




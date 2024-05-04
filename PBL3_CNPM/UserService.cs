using Microsoft.Data.SqlClient;
using PBL3_CNPM.Models;

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
        public LuongNv GetLuongById(string IdUser)
        {
            LuongNv luongNv = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM LuongNV WHERE [Ma NV] = @MaNV";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@MaNV", IdUser);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    luongNv = new LuongNv();
                    luongNv.MaNv = reader["Ma NV"].ToString();
                    luongNv.MaLuong = reader["Ma Luong"].ToString();
                    luongNv.NgayCong = Convert.ToInt16(reader["Ngay cong"]);
                    luongNv.Thuong = Convert.ToDecimal(reader["Thuong"]);
                    luongNv.Phat = Convert.ToDecimal(reader["Phat"]);
                    luongNv.Thang = Convert.ToInt16(reader["Thang"]);
                }
            }
            return luongNv;
        }
        
        

        
    
    public LuongNv Getluongnv(string IdUser)
    {
        LuongNv user = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
                string sqlQuery = "SELECT * FROM LuongNV WHERE [Ma NV] = @MaNV";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@MaNV", IdUser);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
            {
                user = new LuongNv();
                user.MaNv = reader["Ma NV"].ToString();
                user.MaLuong = reader["Ma Luong"].ToString();
                user.NgayCong = Convert.ToInt16(reader["Ngay cong"].ToString());
                user.Thuong = Convert.ToDecimal(reader["Thuong"].ToString());
                user.Phat = Convert.ToDecimal(reader["Phat"].ToString());
                user.LuongTong = Convert.ToDecimal(reader["Luong Tong"].ToString());
            }
        }
        return user;
    }
}
}




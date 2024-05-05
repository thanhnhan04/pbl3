using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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


        public List<(Luong, LuongNv)> GetCombinedData(string IdUser)
        {
            List<(Luong, LuongNv)> combinedDataList = new List<(Luong, LuongNv)>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"SELECT L.*, LN.*
                            FROM Luong AS L
                            INNER JOIN LuongNV AS LN ON L.[Ma Luong] = LN.[Ma Luong]
                            WHERE LN.[Ma NV] = @MaNV";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@MaNV", IdUser);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Luong luong = new Luong
                    {
                        MaLuong = reader["Ma Luong"].ToString(),
                        TenMaLuong = reader["Ten Ma Luong"].ToString(),
                        LuongCoBan = Convert.ToDecimal(reader["Luong Co Ban"]),
                        PhuCap = Convert.ToDecimal(reader["Phu Cap"])
                    };

                    LuongNv luongNv = new LuongNv
                    {
                        MaNv = reader["Ma NV"].ToString(),
                        NgayCong = Convert.ToInt16(reader["Ngay cong"]),
                        Thuong = Convert.ToDecimal(reader["Thuong"]),
                        Phat = Convert.ToDecimal(reader["Phat"]),
                        Thang = Convert.ToInt16(reader["Thang"])
                    };

                    combinedDataList.Add((luong, luongNv));
                }
            }

            return combinedDataList;
        }
        public Luong GetLuong( string IdUser)
        {
            Luong luong = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlquery = "SELECT * FROM Luong WHERE [Ma Luong] = @MaLuong";

                SqlCommand command = new SqlCommand(sqlquery, connection);
                command.Parameters.AddWithValue("@MaLuong", IdUser);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    luong = new Luong();
                    luong.MaLuong = reader["Ma Luong"].ToString();
                    luong.LuongCoBan = Convert.ToDecimal(reader["LuongCoBan"]);
                    luong.PhuCap = Convert.ToDecimal(reader["PhuCap"]);
                }
                return luong;
            }    
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
                    luongNv.Thang = Convert.ToUInt16(reader["Thang"]);
                }
            }
            return luongNv;
        }






    }
}




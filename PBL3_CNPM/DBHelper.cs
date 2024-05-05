using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using PBL3_CNPM.Models;


namespace PBL3_CNPM
{
    public class DBHelper
    {
        private string _connectionString;

        public DBHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<(Nhanvien, Luong, LuongNv)> GetCombinedData(string IdUser)
        {
            List<(Nhanvien, Luong, LuongNv)> combinedDataList = new List<(Nhanvien, Luong, LuongNv)>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"SELECT * 
                                FROM Nhanvien AS N 
                                INNER JOIN LuongNV AS LN ON N.[Ma NV] = LN.[Ma NV]
                                INNER JOIN Luong AS L ON LN.[Ma Luong] = L.[Ma Luong]
                                WHERE N.[Ma NV] = @MaNV";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@MaNV", IdUser);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Nhanvien nhanvien = new Nhanvien
                    {
                        MaNv = reader["Ma NV"].ToString(),
                        TenNhanVien = reader["Ten Nhan Vien"].ToString(),
                        GioiTinh = reader["Gioi Tinh"].ToString(),
                        DiaChi = reader["Dia Chi"].ToString(),
                        Cccd = reader["CCCD"].ToString(),
                        SoDienThoai = reader["So Dien Thoai"].ToString(),
                        Email = reader["Email"].ToString(),
                        TenNganHang = reader["Ten Ngan Hang"].ToString(),
                        TaiKhoanNganHang = reader["Tai Khoan Ngan Hang"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["Ngay Sinh"])
                    };

                    LuongNv luongNv = new LuongNv
                    {
                        MaNv = reader["Ma NV"].ToString(),
                        MaLuong = reader["Ma Luong"].ToString(),
                        NgayCong = Convert.ToInt16(reader["Ngay cong"]),
                        Thuong = Convert.ToDecimal(reader["Thuong"]),
                        Phat = Convert.ToDecimal(reader["Phat"]),
                        Thang = Convert.ToInt16(reader["Thang"])
                    };

                    Luong luong = new Luong
                    {
                        MaLuong = reader["Ma Luong"].ToString(),
                        LuongCoBan = Convert.ToDecimal(reader["Luong Co Ban"]),
                        PhuCap = Convert.ToDecimal(reader["Phu Cap"])
                    };

                  

                    combinedDataList.Add((nhanvien, luong, luongNv));
                }
            }

            return combinedDataList;
        }
    }
}

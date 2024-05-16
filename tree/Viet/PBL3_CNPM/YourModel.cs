using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace PBL3_CNPM
{
    public class YourModel
    {
        public static void UpdateDatabase(HttpContext httpContext, string tennv, DateTime ns, string gt, string dc, string sdt, string em, string stk, string bank)
        {
            // Lấy MaNv từ phiên
            string currentUserId = httpContext.Session.GetString("MaNv");

            // Kiểm tra xem MaNv có tồn tại không
            if (string.IsNullOrEmpty(currentUserId))
            {
                // Nếu không, không thực hiện cập nhật và kết thúc phương thức
                return;
            }

            // Kết nối đến cơ sở dữ liệu và cập nhật dữ liệu.
            string connectionString = "Data Source=LAPTOP-0P18FSJ6\\MYSQL;Initial Catalog=QUANLYNHANVIENKHACHSAN;Integrated Security=True;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Sử dụng tham số @maNv chỉ để truy vấn nhân viên cần cập nhật, không sử dụng để cập nhật trường MaNv
                string query = "UPDATE Nhanvien SET [Ten Nhan Vien]= @tennv, Email= @em, [Ngay Sinh]= @ns, [Dia chi]=@dc," +
                    "[So Dien Thoai]= @sdt, [Tai Khoan Ngan Hang]=@stk, [Ten Ngan Hang]=@bank, [Gioi Tinh]=@gt where [Ma NV]=@maNv";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tennv", tennv);
                command.Parameters.AddWithValue("@ns", ns);
                command.Parameters.AddWithValue("@gt", gt);
                command.Parameters.AddWithValue("@dc", dc);
                command.Parameters.AddWithValue("@sdt", sdt);
                command.Parameters.AddWithValue("@stk", stk);
                command.Parameters.AddWithValue("@bank", bank);
                command.Parameters.AddWithValue("@em", em);
                command.Parameters.AddWithValue("@maNv", currentUserId); // Sử dụng mã nhân viên từ phiên đăng nhập
                command.ExecuteNonQuery();
            }
        }
    }
}

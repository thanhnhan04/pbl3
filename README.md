# Hệ thống Quản lý Nhân viên Khách sạn (Hotel Employee Management System)
Đây là dự án Phần mềm Quản lý Nhân viên Khách sạn (PBL3_CNPM) được xây dựng bằng nền tảng ASP.NET Core MVC. Hệ thống giúp quản lý thông tin nhân sự, chấm công, tính lương và phân quyền cho các bộ phận khác nhau trong khách sạn.
## 🚀 Công nghệ sử dụng
- **Backend:** C# / .NET 8.0, ASP.NET Core MVC
- **Cơ sở dữ liệu:** Microsoft SQL Server
- **ORM:** Entity Framework Core (v9.0.0-preview)
- **Giao diện:** HTML, CSS, JavaScript, Bootstrap (hoặc thư viện tương đương có trong dự án)
- **Thư viện khác:** SweetAlert2 (Thông báo người dùng)
## 🎯 Chức năng chính (Phân quyền)
Hệ thống được thiết kế với các phân quyền rõ ràng:
1. **Quản lý (Manager):**
   - Quản lý toàn bộ nhân viên, phòng ban, chức vụ.
   - Thêm, sửa, xóa thông tin nhân viên.
   - Quản lý và phân công công việc.
   - Thống kê và theo dõi tổng quan.
2. **Kế toán (Accountant):**
   - Quản lý bảng lương nhân viên.
   - Theo dõi chấm công, tính toán lương thưởng.
   - Xuất báo cáo lương.
3. **Nhân viên (Employee):**
   - Xem thông tin cá nhân.
   - Xem lịch làm việc / công việc được giao.
   - Xem bảng lương cá nhân.
4. **Chức năng chung:**
   - Đăng nhập / Đăng xuất hệ thống.
   - Đổi mật khẩu tài khoản.
## 📁 Cấu trúc dự án
- **Controllers/:** Chứa các điều khiển xử lý logic ứng dụng (LoginController, QuanlyController, NhanvienController, KetoanController,...).
- **Models/:** Các lớp mô hình dữ liệu (Nhanvien, Phongban, Chucvu, Luong, Taikhoan,...). Chứa file `QuanlynhanvienkhachsanContext.cs` (Entity Framework Context).
- **Views/:** Chứa giao diện người dùng (.cshtml) chia theo từng Controller tương ứng.
- **wwwroot/:** Chứa các file tĩnh (CSS, JS, hình ảnh, file upload).
## ⚙️ Hướng dẫn cài đặt và chạy dự án
1. **Yêu cầu hệ thống:**
   - [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
   - [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) & SQL Server Management Studio (SSMS)
   - Visual Studio 2022 (khuyên dùng) hoặc Visual Studio Code.
2. **Cấu hình Cơ sở dữ liệu:**
   - Mở file `appsettings.json` và cấu hình chuỗi kết nối (`DefaultConnection`) cho phù hợp với SQL Server cục bộ của bạn.
   - Chạy lệnh Update-Database (nếu sử dụng Code-First Migration) hoặc import file script SQL (nếu có) để tạo cơ sở dữ liệu `Quanlynhanvienkhachsan`.
3. **Chạy ứng dụng:**
   - Nếu dùng Visual Studio: Mở file `PBL3_CNPM.sln` và nhấn `F5` hoặc nút Run.
   - Nếu dùng CLI: Mở terminal tại thư mục gốc của dự án và chạy lệnh:
     ```bash
     dotnet build
     dotnet run
     ```
   - Truy cập vào địa chỉ `http://localhost:<port>` trên trình duyệt.
## 🤝 Thành viên nhóm / Tác giả
- (Điền thông tin nhóm hoặc tác giả tại đây)

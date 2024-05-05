using Microsoft.AspNetCore.Mvc;
using PBL3_CNPM.Models;
using PBL3_CNPM.Models.Authentication;
using System.Diagnostics;

namespace PBL3_CNPM.Controllers
{
    public class NhanvienController : Controller
    {
        private readonly ILogger<NhanvienController> _logger;

        public NhanvienController(ILogger<NhanvienController> logger)
        {
            _logger = logger;
        }
        [Authentication]
        public IActionResult Index()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authentication]

        public IActionResult thongtin()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");

            if (string.IsNullOrEmpty(currentUserId))
            {

                return RedirectToAction("Login", "Login");
            }
            UserService user = new UserService("Data Source=DESKTOP-SP2HFDB;Initial Catalog=QUANLYNHANVIENKHACHSAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            Nhanvien nv = user.GetUserById(currentUserId);
            return View(nv);
        }
        [Authentication]
        //public IActionResult Luongcanhan()
        //{
        //    string currentUserId = HttpContext.Session.GetString("MaNv");

        //    if (string.IsNullOrEmpty(currentUserId))
        //    {
        //        return RedirectToAction("Login", "Login");
        //    }
        //    UserService user = new UserService("Data Source=DESKTOP-SP2HFDB;Initial Catalog=QUANLYNHANVIENKHACHSAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        //    // Khởi tạo đối tượng để lưu dữ liệu từ hai bảng
        //    LuongNvCombined luongNvCombined = new LuongNvCombined();

        //    // Gọi hàm GetLuong để lấy thông tin lương từ bảng Luong
        //    Luong luong = user.GetLuong(currentUserId);
        //    if (luong != null)
        //    {
        //        luongNvCombined.Luong = luong;
        //    }

        //    // Gọi hàm GetLuongById để lấy thông tin lương nhân viên từ bảng LuongNv
        //    LuongNv luongNv = user.GetLuongById(currentUserId);
        //    if (luongNv != null)
        //    {
        //        luongNvCombined.LuongNv = luongNv;
        //    }

        //    // Trả về view và truyền đối tượng LuongNvCombined vào view
        //    return View(luongNvCombined);
        //}

        //public IActionResult Luongcanhan()
        //{
        //    string currentUserId = HttpContext.Session.GetString("MaNv");

        //    if (string.IsNullOrEmpty(currentUserId))
        //    {

        //        return RedirectToAction("Login", "Login");
        //    }


        //    UserService user = new UserService("Data Source=DESKTOP-SP2HFDB;Initial Catalog=QUANLYNHANVIENKHACHSAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");




        //    LuongNv luongNv = user.GetLuongById(currentUserId);


        //    return View(luongNv);
        //}
        public IActionResult Luongcanhan()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");

            if (string.IsNullOrEmpty(currentUserId))
            {
                return RedirectToAction("Login", "Login");
            }

            UserService user = new UserService("Data Source=DESKTOP-SP2HFDB;Initial Catalog=QUANLYNHANVIENKHACHSAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            // Lấy thông tin từ bảng Luong
            Luong luong = user.GetLuong(currentUserId);

            // Lấy thông tin từ bảng LuongNv
            LuongNv luongNv = user.GetLuongById(currentUserId);

            // Khởi tạo đối tượng ViewModel và gán dữ liệu
            LuongNvCombined viewModel = new LuongNvCombined
            {
                Luong = luong,
                LuongNv = luongNv
            };

            return View(viewModel);
        }

        public IActionResult chinhsua()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");

            // Kiểm tra xem người dùng đã đăng nhập hay chưa
            if (string.IsNullOrEmpty(currentUserId))
            {
                // Nếu không có thông tin người dùng, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login", "Login");
            }
            UserService user = new UserService("Data Source=DESKTOP-SP2HFDB;Initial Catalog=QUANLYNHANVIENKHACHSAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            Nhanvien nv = user.GetUserById(currentUserId);
            return View(nv);
          
        }
    }
}

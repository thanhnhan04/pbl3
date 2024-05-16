using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PBL3_CNPM.Models;
using PBL3_CNPM.Models.Authentication;
using System;
using System.Diagnostics;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PBL3_CNPM.Controllers
{
    public class NhanvienController : Controller
    {
        private readonly QuanlynhanvienkhachsanContext _masterContext;
        private readonly ILogger<NhanvienController> _logger;

        public NhanvienController(ILogger<NhanvienController> logger)
        {
            _masterContext = new  ();
            _logger = logger;
        }
        QuanlynhanvienkhachsanContext db = new QuanlynhanvienkhachsanContext();
        [HttpGet]
        //  [Authentication]
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
            Nhanvien nv = db.Nhanviens.Find(currentUserId);
            return View(nv);
        }
        [Authentication]
        public IActionResult Luongcanhan()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");

            if (string.IsNullOrEmpty(currentUserId))
            {

                return RedirectToAction("Login", "Login");
            }
             /*UserService user = new UserService("Data Source=LAPTOP-0P18FSJ6\\MYSQL;Initial Catalog=QUANLYNHANVIENKHACHSAN;Integrated Security=True;Encrypt=False");
             LuongNv luong = user.GetLuongNv(currentUserId);*/
             LuongNv luong = db.LuongNvs.Include(p => p.MaLuongNavigation).FirstOrDefault(p => p.MaNv == currentUserId);
            var luongnv = new LuongIfo
            {
                LuongNv = luong,
                Luong = luong.MaLuongNavigation
            };

            return View(luongnv);

        }
        [HttpPost]
        public ActionResult chinhsua( string tennv, DateTime ns, string gt, string dc, string sdt, string em, string stk, string bank)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            var nvUp = db.Nhanviens.FirstOrDefault(e => e.MaNv == currentUserId);
            if (nvUp !=null)
            {
                nvUp.TenNhanVien = tennv;
                nvUp.NgaySinh = Convert.ToDateTime(ns);
                nvUp.GioiTinh = gt;
                nvUp.DiaChi = dc;
                nvUp.SoDienThoai = sdt;
                nvUp.Email = em;
                nvUp.TaiKhoanNganHang = stk;
                nvUp.TenNganHang = bank;
                db.SaveChanges();
                return RedirectToAction("thongtin");
            }
            else
            {
                return View();
            }

        }
        public IActionResult chinhsua()
        {
            // Lấy MaNv từ phiên
            string currentUserId = HttpContext.Session.GetString("MaNv");

            // Kiểm tra xem MaNv có tồn tại không
            if (string.IsNullOrEmpty(currentUserId))
            {
                // Nếu không, chuyển hướng đến trang đăng nhập
                return RedirectToAction("Login", "Login");
            }

            Nhanvien nv = db.Nhanviens.Find(currentUserId);

            // Trả về view với thông tin người dùng
            return View(nv);
        }

        [Authentication]
        public IActionResult Lichlamvieccanhan()
        {
            try
            {
                string currentUserId = HttpContext.Session.GetString("MaNv");

                if (string.IsNullOrEmpty(currentUserId))
                {
                  
                    return RedirectToAction("Login", "Login");
                }
             
                var user = _masterContext.Nhanviens.FirstOrDefault(u => u.MaNv ==currentUserId);

                if (user == null)
                {
                    
                    return NotFound("Không tìm thấy thông tin của người dùng.");
                }

            
                var lichLamViecList = (from cnv in _masterContext.CongviecNvs
                                       join cv in _masterContext.Congviecs on cnv.MaCongViec equals cv.MaCongViec
                                       where cnv.MaNv == currentUserId
                                       select new
                                       {
                                           MaCongViec = cv.MaCongViec,
                                           CaLam = cv.CaLam,
                                           ChiTietCongViec = cv.ChiTietCongViec,
                                           NgayLam = cnv.NgayLam
                                       }).ToList();

                ViewBag.LichLamViec = lichLamViecList;

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy danh sách công việc cá nhân: {ex.Message}");
                throw; 
            }
        }
    
}
}

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
        public IActionResult Luongcanhan()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");

            if (string.IsNullOrEmpty(currentUserId))
            {

                return RedirectToAction("Login", "Login");
            }
            UserService user = new UserService("Data Source = DESKTOP - SP2HFDB; Initial Catalog = QUANLYNHANVIENKHACHSAN; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
            LuongNv luong = user.GetLuongNv(currentUserId);
            return View(luong);

        }

        [Authentication]
        public IActionResult chinhsua()
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

//using Elfie.Serialization;
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
            _masterContext = new();
            _logger = logger;
        }
        QuanlynhanvienkhachsanContext db = new QuanlynhanvienkhachsanContext();
        [Authentication]
        public IActionResult thongtin()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            if (string.IsNullOrEmpty(currentUserId))
            {
                return RedirectToAction("Login", "Login");
            }
            Nhanvien nv = db.Nhanviens.Include(p => p.MaPhongBanNavigation).Include(p => p.MaChucVuNavigation).FirstOrDefault(p => p.MaNv == currentUserId);
            return View(nv);
        }
        [HttpGet]
        [Authentication]
        public IActionResult Luongcanhan(string thang)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            DateTime month;
            if (DateTime.TryParse(thang, out month))
            {
                try
                {
                    if (string.IsNullOrEmpty(currentUserId))
                    {
                        return RedirectToAction("Login", "Login");
                    }
                    var luongcanhanList = from ln in _masterContext.LuongNvs

                                          join l in _masterContext.Luongs on ln.MaLuong equals l.MaLuong
                                          where ln.MaNv == currentUserId && ln.Thang == month
                                          select new
                                          {
                                              PhuCap = l.PhuCap,
                                              Thang = ln.Thang,
                                              Phat = ln.Phat,
                                              NgayCong = ln.NgayCong,
                                              LuongCoBan = l.LuongCoBan,
                                              Thuong = ln.Thuong,
                                              TongLuong = ln.LuongTong,
                                          };

                    ViewBag.LuongCanhan = luongcanhanList.FirstOrDefault(); // Lấy bản ghi đầu tiên hoặc null nếu không tìm thấy

                    return View();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Lỗi khi lấy thông tin lương cá nhân: {ex.Message}");
                    // Optionally, return an error view or message
                    return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
            }
            else
            {
                return View();
            };
        }
        [HttpPost]
        [Authentication]
        public ActionResult Chinhsua(string tennv, DateTime ns, string gt, string dc, string sdt, string em, string stk, string bank)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            var nvUp = db.Nhanviens.FirstOrDefault(e => e.MaNv == currentUserId);
            if (nvUp != null)
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
        [Authentication]
        public IActionResult chinhsua()
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
        public IActionResult Lichlamvieccanhan()
        {
            try
            {
                string currentUserId = HttpContext.Session.GetString("MaNv");
                ViewBag.Message = currentUserId;
                if (string.IsNullOrEmpty(currentUserId))
                {

                    return RedirectToAction("Login", "Login");
                }

                var user = _masterContext.Nhanviens.FirstOrDefault(u => u.MaNv == currentUserId);

                if (user == null)
                {

                    return NotFound("Không tìm thấy thông tin của người dùng.");
                }

                DateTime today = DateTime.Now.Date;
                DateTime nextWeek = today.AddDays(7);
                var lichLamViecList = (from cnv in _masterContext.CongviecNvs
                                       join cv in _masterContext.Congviecs on cnv.MaCongViec equals cv.MaCongViec
                                       where cnv.MaNv == currentUserId && cnv.NgayLam >= today && cnv.NgayLam <= nextWeek
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

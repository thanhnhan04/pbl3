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
    public class QuanlyController : Controller
    {

        private readonly QuanlynhanvienkhachsanContext _masterContext;
        private readonly ILogger<QuanlyController> _logger;

        public QuanlyController(ILogger<QuanlyController> logger)
        {
            _masterContext = new();
            _logger = logger;
        }
        QuanlynhanvienkhachsanContext db = new QuanlynhanvienkhachsanContext();
        [HttpGet]
        [Authentication]
        public IActionResult quanlyhoso()
        {
            var nv = db.Nhanviens.Where(p => p.MaPhanQuyen == "103").Select(p => p);
            return View(nv.ToList());
        }
        [Authentication]
        public IActionResult themhoso()
        {
            return View(new Nhanvien());
        }
        [HttpPost]
        [Authentication]
        public ActionResult themhoso(string maNV, string tennv, DateTime ns, string gt, string dc, string sdt, string em, string stk, string bank, string cccd, string maBH, string pass)
        {
            Nhanvien nv = new Nhanvien();
            nv.MaNv = maNV;
            nv.TenNhanVien = tennv;
            nv.NgaySinh = ns;
            nv.GioiTinh = gt;
            nv.DiaChi = dc;
            nv.SoDienThoai = sdt;
            nv.Email = em;
            nv.TaiKhoanNganHang = stk;
            nv.TenNganHang = bank;
            nv.Cccd = cccd;
            nv.MaBaoHiem = maBH;
            nv.Password = pass;
            nv.MaPhanQuyen = "103";
            db.Nhanviens.Add(nv);
            db.SaveChanges();
            return RedirectToAction("quanlyhoso", "Quanly");
        }
        [Authentication]
        public IActionResult Quanlycongviec()
        {
            return View();
        
        }
        [Authentication]
        [HttpGet]
        public IActionResult Phongban()
        {
            try
            {
                // Lấy danh sách phòng ban từ cơ sở dữ liệu
                var phongBans = _masterContext.Phongbans.ToList();

                // Gán danh sách phòng ban vào ViewBag
                ViewBag.PhongBans = phongBans;

                // Trả về view
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy danh sách phòng ban: {ex.Message}");
                throw; // Ném lại exception để xử lý ở mức cao hơn
            }
        }
        [Authentication]
        public IActionResult DisplayNhanVienByPhongBan(string selectedPhongBan)
        {
            if (string.IsNullOrEmpty(selectedPhongBan))
            {
                // Nếu không có phòng ban được chọn, hiển thị lại trang Index
                return RedirectToAction("Phongban");
            }

            var danhSachNhanVien = _masterContext.Nhanviens
                .Where(nv => nv.MaPhongBan == selectedPhongBan)
                .ToList();
            ViewBag.DanhSachNhanVien = danhSachNhanVien;
            ViewBag.SelectedPhongBan = selectedPhongBan;

            return View("Phongban");
        }
        [HttpPost]
     [Authentication]
        public IActionResult RemoveEmployeeFromPhongBan(string maNv)
        {
            try
            {
                // Tìm nhân viên cần xóa từ database
                var employee = _masterContext.Nhanviens.FirstOrDefault(e => e.MaNv == maNv);

                if (employee != null)
                {
                    // Xóa nhân viên ra khỏi phòng ban
                    employee.MaPhongBan = null; // Gán MaPhongBan của nhân viên thành null để xóa ra khỏi phòng ban
                    _masterContext.SaveChanges(); // Lưu thay đổi vào database

                    return Ok(); // Trả về mã HTTP 200 OK nếu xóa thành công
                }
                else
                {
                    return NotFound(); // Trả về mã HTTP 404 Not Found nếu không tìm thấy nhân viên
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi xóa nhân viên: {ex.Message}"); // Trả về mã HTTP 500 Internal Server Error nếu có lỗi xảy ra
            }
        }
        public IActionResult AddEmployeeToPhongBan(string maNv, string selectedPhongBan)
        {
            try
            {
                // Kiểm tra xem mã nhân viên có tồn tại không
                var employee = _masterContext.Nhanviens.FirstOrDefault(e => e.MaNv == maNv);

                if (employee != null)
                {
                    // Cập nhật trường MaPhongBan của nhân viên
                    employee.MaPhongBan = selectedPhongBan;
                    _masterContext.SaveChanges();

                    return RedirectToAction("Phongban");
                }
                else
                {
                    // Không tìm thấy nhân viên với mã nhân viên đã nhập
                    TempData["ErrorMessage"] = "Không tìm thấy nhân viên với mã đã nhập.";
                    return RedirectToAction("Phongban");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi thêm nhân viên vào phòng ban: {ex.Message}");
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi thêm nhân viên.";
                return RedirectToAction("Phongban");
            }
        }
        [Authentication]
        public IActionResult Lichlamviec(DateTime? strSearch)
        {
            try
            {
                IQueryable<object> lichLamViecList;

                
                if (strSearch.HasValue)
                {
                    lichLamViecList = (from cnv in _masterContext.CongviecNvs
                                       join cv in _masterContext.Congviecs on cnv.MaCongViec equals cv.MaCongViec
                                       join nv in _masterContext.Nhanviens on cnv.MaNv equals nv.MaNv
                                       where cnv.NgayLam.Date == strSearch.Value.Date
                                       select new
                                       {
                                           MaNv = cnv.MaNv,
                                           TenNhanVien = nv.TenNhanVien,
                                           MaCongViec = cv.MaCongViec,
                                           CaLam = cv.CaLam,
                                           ChiTietCongViec = cv.ChiTietCongViec,
                                           NgayLam = cnv.NgayLam
                                       });
                }
                else
                {
                    
                    lichLamViecList = (from cnv in _masterContext.CongviecNvs
                                       join cv in _masterContext.Congviecs on cnv.MaCongViec equals cv.MaCongViec
                                       join nv in _masterContext.Nhanviens on cnv.MaNv equals nv.MaNv
                                       select new
                                       {
                                           MaNv = cnv.MaNv,
                                           TenNhanVien =nv.TenNhanVien,
                                           MaCongViec = cv.MaCongViec,
                                           CaLam = cv.CaLam,
                                           ChiTietCongViec = cv.ChiTietCongViec,
                                           NgayLam = cnv.NgayLam
                                       });
                }

                ViewBag.LichLamViec = lichLamViecList.ToList();

                return View();
            }
            catch (Exception ex)
            {
                
                _logger.LogError($"Lỗi khi lấy danh sách công việc nhân viên: {ex.Message}");
                throw;
            }
        }
        public IActionResult Chinhsua()
        {
            return View();
        }
        public IActionResult Sapxepcongviec()
        {
            return View();
        }


       


    }
}

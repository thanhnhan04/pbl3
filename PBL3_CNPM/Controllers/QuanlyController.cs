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
        public IActionResult quanlyhoso(string searchString)
        {

            var nv = db.Nhanviens.Where(p => p.MaPhanQuyen == "103").Select(p => p);
            if (!string.IsNullOrEmpty(searchString))
            {
                nv = nv.Where(e => e.TenNhanVien.Contains(searchString));
            }
            ViewBag.SearchString = searchString;
            return View(nv.ToList());
        }
        [Authentication]
        public IActionResult themhoso()
        {
            var cv = db.Chucvus.ToList();
            return View(cv);
        }
        [HttpPost]
        [Authentication]
        public ActionResult themhoso(string maNV, string tennv, DateTime ns, string gt, string dc, string sdt, string em, string stk, string bank, string cccd, string maBH, string pass, string cv, string td, string kn)
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
            nv.MaChucVu = cv;
            nv.TrinhDo = td;
            nv.KinhNghiem = kn;

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

            var danhSachNhanVien = db.Nhanviens
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
                var employee = db.Nhanviens.FirstOrDefault(e => e.MaNv == maNv);

                if (employee != null)
                {
                    // Xóa nhân viên ra khỏi phòng ban
                    employee.MaPhongBan = null; // Gán MaPhongBan của nhân viên thành null để xóa ra khỏi phòng ban
                    db.SaveChanges(); // Lưu thay đổi vào database

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
        [Authentication]
        public IActionResult AddEmployeeToPhongBan(string maNv, string selectedPhongBan)
        {
            try
            {
                // Kiểm tra xem mã nhân viên có tồn tại không
                var employee = db.Nhanviens.FirstOrDefault(e => e.MaNv == maNv);

                if (employee != null)
                {
                    // Cập nhật trường MaPhongBan của nhân viên
                    employee.MaPhongBan = selectedPhongBan;
                    db.SaveChanges();

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
        public IActionResult AddPhongBan(string maPhongBan, string tenPhongBan)
        {
            try
            {

                Phongban phongBan = new Phongban
                {
                    MaPhongBan = maPhongBan,
                    TenPhongBan = tenPhongBan
                };

                db.Phongbans.Add(phongBan);
                db.SaveChanges();

                return RedirectToAction("Phongban");
            }
            catch (Exception ex)
            {

                _logger.LogError($"Lỗi khi thêm phòng ban mới: {ex.Message}");
                throw;
            }
        }
        //  [Authentication]
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
                                           MaCongViecNv = cnv.MaCongViecNv,
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
                                           MaCongViecNv = cnv.MaCongViecNv,
                                           MaNv = cnv.MaNv,
                                           TenNhanVien = nv.TenNhanVien,
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
        public IActionResult xoalichlamviec(int id)
        {
            var cv = db.CongviecNvs.Find(id);

            if (cv == null)
            {

                return RedirectToAction("Error");
            }
            // var cv = db.CongviecNvs.Find(id);
            db.CongviecNvs.Remove(cv);
            db.SaveChanges();
            return RedirectToAction("Lichlamviec");
        }
        [Authentication]
        public IActionResult Chinhsua(string id)
        {
            var cv = db.Chucvus.ToList();
            ViewBag.chucvulist = cv;
            var nv = db.Nhanviens.Find(id);
            return View(nv);
        }
        [HttpPost]
        public ActionResult Chinhsua(string pass, string cccd, string td, string kn, string maBH, string cv, string maNV, string tennv, DateTime ns, string gt, string dc, string sdt, string em, string stk, string bank)
        {
            var nvUp = db.Nhanviens.FirstOrDefault(e => e.MaNv == maNV);
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
                nvUp.MaChucVu = cv;
                nvUp.MaBaoHiem = maBH;
                nvUp.KinhNghiem = kn;
                nvUp.TrinhDo = td;
                nvUp.Cccd = cccd;
                nvUp.Password = pass;
                db.SaveChanges();
                return RedirectToAction("quanlyhoso");
            }
            else
            {
                return View();
            }

        }

        [HttpPost, ActionName("xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult xoa(string id)
        {
            var nv = db.Nhanviens.Find(id);
            db.Nhanviens.Remove(nv);
            db.SaveChanges();
            return RedirectToAction("quanlyhoso");

        }
        // [Authentication]
        public IActionResult CongViec()
        {
            var cv = db.Congviecs.ToList();
            ViewBag.cv = cv;

            return View();

        }

        public IActionResult Chinhsuacongviec(int id)
        {
            var cv = db.Congviecs.FirstOrDefault(x => x.MaCongViec == id);
            return View(cv);
        }
        [HttpPost]

        public IActionResult Chinhsuacongviec(int macv, string CaLam, string ChiTietCongViec)
        {
            if (ModelState.IsValid)
            {
                var congviec = db.Congviecs.FirstOrDefault(x => x.MaCongViec == macv);
                if (congviec != null)
                {
                    congviec.ChiTietCongViec = ChiTietCongViec;
                    congviec.CaLam = CaLam;
                    db.SaveChanges();
                    return RedirectToAction("CongViec");
                }
                else
                {
                    ModelState.AddModelError("", "Không tìm thấy công việc");
                }
            }

            // Fetch the task again to pass back to the view
            var viewModel = db.Congviecs.FirstOrDefault(x => x.MaCongViec == macv);
            return View(viewModel);
        }




        public IActionResult Xoacongviec(int id)
        {
            var cv = db.Congviecs.Find(id);
            db.Congviecs.Remove(cv);
            db.SaveChanges();
            return RedirectToAction("CongViec");
        }
        public IActionResult themcongviec()
        {

            var cv = db.Congviecs.ToList();
            return View(cv);

        }

        [HttpPost]

        public IActionResult themcongviec(int macv, string CaLam, string ChiTietCongViec)
        {

            Congviec congviec = new Congviec();

            congviec.CaLam = CaLam;
            congviec.ChiTietCongViec = ChiTietCongViec;
            db.Congviecs.Add(congviec);
            db.SaveChanges();


            return RedirectToAction("CongViec");
        }


        public IActionResult Sapxepcongviec()
        {

            var cv = db.Congviecs.ToList();

            var nv = db.Nhanviens.ToList();

            ViewBag.Congviecs = cv;
            ViewBag.NhanViens = nv;
            return View();


        }

        [HttpPost]
        public ActionResult Sapxepcongviec(CongviecNv congviecnv)
        {
            try
            {
                if (congviecnv == null || congviecnv.MaCongViec == 0 || string.IsNullOrEmpty(congviecnv.MaNv) || congviecnv.NgayLam == DateTime.MinValue)
                {
                    TempData["ErrorMessage"] = "Thông tin công việc không hợp lệ. Vui lòng kiểm tra lại.";
                    return RedirectToAction("Sapxepcongviec");
                }

                // Kiểm tra xem công việc đã được xếp cho nhân viên vào ngày đó chưa
                bool isAssigned = db.CongviecNvs.Any(cv => cv.MaCongViec == congviecnv.MaCongViec && cv.NgayLam == congviecnv.NgayLam);
                if (isAssigned)
                {
                    TempData["ErrorMessage"] = $"Công việc {congviecnv.MaCongViec} đã được xếp cho ít nhất một nhân viên vào ngày {congviecnv.NgayLam:dd/MM/yyyy}.";
                    return RedirectToAction("Sapxepcongviec");
                }

                // Lấy danh sách mã nhân viên đã chọn
                string[] maNvList = congviecnv.MaNv.Split(',');

                // Thêm công việc cho từng nhân viên trong danh sách
                foreach (var maNv in maNvList)
                {
                    if (!string.IsNullOrEmpty(maNv.Trim()))
                    {
                        CongviecNv newCongviecnv = new CongviecNv
                        {
                            MaCongViec = congviecnv.MaCongViec,
                            MaNv = maNv.Trim(),
                            NgayLam = congviecnv.NgayLam
                        };

                        db.CongviecNvs.Add(newCongviecnv);
                    }
                }

                // Lưu các thay đổi vào cơ sở dữ liệu
                db.SaveChanges();

                TempData["SuccessMessage"] = "Thêm công việc thành công.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Thêm công việc thất bại. Lỗi: " + ex.Message;
            }

            return RedirectToAction("Sapxepcongviec");
        }


    }
}







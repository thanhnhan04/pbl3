
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PBL3_CNPM.Models;
using PBL3_CNPM.Models.Authentication;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;


using PBL3_CNPM.Models;
using System.IO;

using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
namespace PBL3_CNPM.Controllers
{
    public class QuanlyController : Controller
    {

       
        private readonly ILogger<QuanlyController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public QuanlyController(ILogger<QuanlyController> logger, IWebHostEnvironment hostingEnvironment)
        {
          
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }
        QuanlynhanvienkhachsanContext db = new QuanlynhanvienkhachsanContext();
        private object _webHostEnvironment;

        [HttpGet]
        [Authentication]
        public IActionResult quanlyhoso(string searchString)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
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
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            int i = db.Nhanviens.Count() - 2;
            Nhanvien nv = db.Nhanviens.ElementAt(i);
            string manv = nv.MaNv.Substring(Math.Max(0, nv.MaNv.Length - 3));
            int so = Int32.Parse(manv);
            so++;
            string id = "NV" + so.ToString();
            ViewBag.Id = id;
            var cv = db.Chucvus.ToList();
            return View(cv);
        }
        [HttpPost]
        [Authentication]
        public ActionResult themhoso(string maNV, string tennv, DateTime ns, string gt, string dc, string sdt, string em, string stk, string bank, string cccd, string maBH, string pass, string cv, string td, string kn /*IFormFile uploadhinh*/)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            try
            {
               
                    Nhanvien nv = new Nhanvien
                    {
                        MaNv = maNV,
                        TenNhanVien = tennv,
                        NgaySinh = ns,
                        GioiTinh = gt,
                        DiaChi = dc,
                        SoDienThoai = sdt,
                        Email = em,
                        TaiKhoanNganHang = stk,
                        TenNganHang = bank,
                        Cccd = cccd,
                        MaBaoHiem = maBH,
                        Password = pass,
                        MaPhanQuyen = "103",
                        MaChucVu = cv,
                        TrinhDo = td,
                        KinhNghiem = kn
                    };

                    db.Nhanviens.Add(nv);
                    db.SaveChanges();
                return RedirectToAction("quanlyhoso", "Quanly");

               
            }
            catch (Exception ex)
            {
                
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        [Authentication]
        public IActionResult Quanlycongviec()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            return View();

        }
        [Authentication]
        [HttpGet]
        public IActionResult Phongban()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            try
            {
               
                var phongBans = db.Phongbans.ToList();
                ViewBag.PhongBans = phongBans;
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi lấy danh sách phòng ban: {ex.Message}");
                throw;
            }
        }
        [Authentication]
        public IActionResult DisplayNhanVienByPhongBan(string selectedPhongBan)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            if (string.IsNullOrEmpty(selectedPhongBan))
            {
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
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            try
            {
                var employee = db.Nhanviens.FirstOrDefault(e => e.MaNv == maNv);

                if (employee != null)
                {
                    employee.MaPhongBan = null; 
                    db.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi xóa nhân viên: {ex.Message}"); 
            }
        }
        [Authentication]
        public IActionResult AddEmployeeToPhongBan(string maNv, string selectedPhongBan)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            try
            {
                
                var employee = db.Nhanviens.FirstOrDefault(e => e.MaNv == maNv);

                if (employee != null)
                {
                    employee.MaPhongBan = selectedPhongBan;
                    db.SaveChanges();

                    return RedirectToAction("Phongban");
                }
                else
                {
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
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
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
        [Authentication]
        public ActionResult khoa(string id, string tk)
        {
            var cv = db.CongviecNvs.Where(p => p.MaNv == id).ToList();
            if (cv.Any())
            {
                foreach (var i in cv)
                {
                    db.CongviecNvs.Remove(i);
                }

            }
            Nhanvien nv = db.Nhanviens.Find(id);
            nv.MaPhongBan = null;
            nv.TrangThai = false;
            db.Nhanviens.Update(nv);
            db.SaveChanges();
            return RedirectToAction("quanlyhoso", new { searchString = tk });
        }
        [Authentication]
        public ActionResult mokhoa(string id, string tk)
        {
            Nhanvien nv = db.Nhanviens.Find(id);
            nv.TrangThai = true;
            db.Nhanviens.Update(nv);
            db.SaveChanges();
            return RedirectToAction("quanlyhoso", new { searchString = tk });
        }
        [Authentication]
        public IActionResult Lichlamviec(DateTime? strSearch)
        {

            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            try
            {
                IQueryable<object> lichLamViecList;


                if (strSearch.HasValue)
                {
                    lichLamViecList = (from cnv in db.CongviecNvs
                                       join cv in db.Congviecs on cnv.MaCongViec equals cv.MaCongViec
                                       join nv in db.Nhanviens on cnv.MaNv equals nv.MaNv
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
                    DateTime today = DateTime.Now.Date;
                    DateTime nextWeek = today.AddDays(7);

                    lichLamViecList = (from cnv in db.CongviecNvs
                                       join cv in db.Congviecs on cnv.MaCongViec equals cv.MaCongViec
                                       join nv in db.Nhanviens on cnv.MaNv equals nv.MaNv
                                       where cnv.NgayLam >= today && cnv.NgayLam <= nextWeek
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
        [Authentication]
        public IActionResult xoalichlamviec(int id)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
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
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            var cv = db.Chucvus.ToList();
            ViewBag.chucvulist = cv;
            var nv = db.Nhanviens.Find(id);
            return View(nv);
        }
        [Authentication]
        [HttpPost]
        public ActionResult Chinhsua(string pass, string cccd, string td, string kn, string maBH, string cv, string maNV, string tennv, DateTime ns, string gt, string dc, string sdt, string em, string stk, string bank)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
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
     
       
        [Authentication]
        public IActionResult CongViec()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            var cv = db.Congviecs.ToList();
            ViewBag.cv = cv;

            return View();

        }
        [Authentication]
        public IActionResult Chinhsuacongviec(int id)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            var cv = db.Congviecs.FirstOrDefault(x => x.MaCongViec == id);
            return View(cv);
        }
        [Authentication]
        [HttpPost]

        public IActionResult Chinhsuacongviec(int macv, string CaLam, string ChiTietCongViec)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
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

           
            var viewModel = db.Congviecs.FirstOrDefault(x => x.MaCongViec == macv);
            return View(viewModel);
        }



        [Authentication]
        public IActionResult Xoacongviec(int id)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            var cv = db.Congviecs.Find(id);
            db.Congviecs.Remove(cv);
            db.SaveChanges();
            return RedirectToAction("CongViec");
        }
        [Authentication]
        public IActionResult themcongviec()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            var cv = db.Congviecs.ToList();
            return View(cv);

        }
        [Authentication]
        [HttpPost]

        public IActionResult themcongviec(int macv, string CaLam, string ChiTietCongViec)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            Congviec congviec = new Congviec();

            congviec.CaLam = CaLam;
            congviec.ChiTietCongViec = ChiTietCongViec;
            db.Congviecs.Add(congviec);
            db.SaveChanges();


            return RedirectToAction("CongViec");
        }

        [Authentication]
        public IActionResult Sapxepcongviec(string searchString )
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            var cv = db.Congviecs.ToList();
            var nv = db.Nhanviens.Include(p => p.MaChucVuNavigation).Where(p => p.MaPhanQuyen == "103").Select(p => new {p.MaNv, p.TenNhanVien, p.MaChucVuNavigation.ChucVu});
            if (!string.IsNullOrEmpty(searchString))
            {
                nv = nv.Where(e => e.TenNhanVien.Contains(searchString));
            }
            ViewBag.SearchString = searchString;
            ViewBag.Congviecs = cv;
            ViewBag.NhanViens = nv;
            return View();


        }
        [Authentication]
        [HttpPost]
        public ActionResult Sapxepcongviec(CongviecNv congviecnv, string[] MaNv)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            try
            {
                if (congviecnv == null || congviecnv.MaCongViec == 0 || MaNv == null || MaNv.Length == 0 || congviecnv.NgayLam == DateTime.MinValue)
                {
                    TempData["ErrorMessage"] = "Thông tin công việc không hợp lệ. Vui lòng kiểm tra lại.";
                    return RedirectToAction("Sapxepcongviec");
                }

            
                bool isAssigned = db.CongviecNvs.Any(cv => cv.MaCongViec == congviecnv.MaCongViec && cv.NgayLam == congviecnv.NgayLam);
                if (isAssigned)
                {
                    TempData["ErrorMessage"] = $"Công việc {congviecnv.MaCongViec} đã được xếp cho ít nhất một nhân viên vào ngày {congviecnv.NgayLam:dd/MM/yyyy}.";
                    return RedirectToAction("Sapxepcongviec");
                }

               
                foreach (var maNv in MaNv)
                {
                    if (!string.IsNullOrEmpty(maNv.Trim()))
                    {
                        bool isEmployeeAssigned = db.CongviecNvs.Any(cv => cv.MaNv == maNv.Trim() && cv.NgayLam == congviecnv.NgayLam);
                        if (isEmployeeAssigned)
                        {
                            TempData["ErrorMessage"] = $"Nhân viên {maNv.Trim()} đã được xếp công việc vào ngày {congviecnv.NgayLam:dd/MM/yyyy}.";
                            return RedirectToAction("Sapxepcongviec");
                        }

                        CongviecNv newCongviecnv = new CongviecNv
                        {
                            MaCongViec = congviecnv.MaCongViec,
                            MaNv = maNv.Trim(),
                            NgayLam = congviecnv.NgayLam
                        };

                        db.CongviecNvs.Add(newCongviecnv);
                    }
                }

                db.SaveChanges();

                TempData["SuccessMessage"] = "Thêm công việc thành công.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Thêm công việc thất bại. Lỗi: " + ex.Message;
            }

            return RedirectToAction("Sapxepcongviec");
        }
        [Authentication]
        [HttpGet]
        public ActionResult chinhsualichlamviec(int id)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            var cvv = db.Congviecs.ToList();
            var result = (from cvnv in db.CongviecNvs
                          join cv in db.Congviecs on cvnv.MaCongViec equals cv.MaCongViec
                          join nv in db.Nhanviens on cvnv.MaNv equals nv.MaNv
                          where cvnv.MaCongViecNv == id
                          select new ChinhSuaLichLamViecViewModel
                          {
                              CongviecNv = cvnv,
                              Congviec = cv,
                              TenNhanVien = nv.TenNhanVien
                          }).FirstOrDefault();

            if (result == null)
            {
               
                return NotFound();
            }
            ViewBag.SelectedCongViec = result.CongviecNv.MaCongViec;

            ViewBag.Congviec= cvv;
            return View(result);
        }

        [Authentication]
        [HttpPost]
        public ActionResult chinhsualichlamviec( int MaCongViec, int MaCongViecNv, DateTime NgayLam)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            if (ModelState.IsValid)
            {
                var congviecnv = db.CongviecNvs.FirstOrDefault(x => x.MaCongViecNv == MaCongViecNv );
                if (congviecnv != null)
                {
                    congviecnv.MaCongViec = MaCongViec;
                    congviecnv.NgayLam = NgayLam;
                    db.SaveChanges();
                    return RedirectToAction("Lichlamviec");
                }
                else
                {
                    ModelState.AddModelError("", "Không tìm thấy công việc");
                }
            }

           
            var viewModel = db.CongviecNvs.FirstOrDefault(x => x.MaCongViecNv == MaCongViecNv);
            return View(viewModel);
        }


    }
}







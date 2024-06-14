using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PBL3_CNPM.Models;
using PBL3_CNPM.Models.Authentication;
using System;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PBL3_CNPM.Controllers
{
    public class KetoanController : Controller
    {
        QuanlynhanvienkhachsanContext db = new QuanlynhanvienkhachsanContext();
        [Authentication]
        public IActionResult Trangchuketoan()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            DateTime now = DateTime.Now;
            ViewBag.thang = now;
            decimal? thuong = 0, phat = 0, pc = 0, lcb = 0;
            var luongnv = db.LuongNvs.Where(p => p.Thang.HasValue && p.Thang.Value.Month == now.Month && p.Thang.Value.Year == now.Year).Select(p => new { p.NgayCong, p.Thuong, p.Phat, p.MaLuongNavigation.PhuCap, p.MaLuongNavigation.LuongCoBan });
            foreach (var i in luongnv.ToList())
            {
                thuong += i.Thuong;
                phat += i.Phat;
                pc += i.PhuCap;
                lcb += i.LuongCoBan * i.NgayCong;
            }
            ViewBag.thuong = thuong;
            ViewBag.phat = phat;
            ViewBag.pc = pc;
            ViewBag.lcb = lcb;
            return View();
        }
        [HttpGet]
        [Authentication]
        public IActionResult bangluong(string thang)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message1 = currentUserId;
            DateTime month;
            if (DateTime.TryParse(thang, out month))
            {
                ViewBag.Message2 = month;
                var luong = db.LuongNvs.Where(p => p.Thang == month).Select(p => new
                {
                    p.MaLuongNv,
                    p.Thang,
                    p.MaNvNavigation.MaNv,
                    p.MaNvNavigation.TenNhanVien,
                    p.MaNvNavigation.TrangThai,
                    p.MaLuongNavigation.LuongCoBan,
                    p.MaLuongNavigation.PhuCap,
                    p.NgayCong,
                    p.Thuong,
                    p.Phat,
                    p.LuongTong
                });
                ViewBag.luong = luong.ToList();
                return View();
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        [Authentication]
        public IActionResult taobangluong(string thang)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message1 = currentUserId;
            DateTime month;
            if (DateTime.TryParse(thang, out month))
            {
                ViewBag.Message2 = month;
                var nv = db.Nhanviens.Where(nv => !nv.LuongNvs.Any(l => l.Thang == month) && nv.MaPhanQuyen == "103").Select(p => new { p.MaNv, p.TenNhanVien, p.MaChucVuNavigation.ChucVu, p.TrangThai }).ToList();
                ViewBag.nv = nv.ToList();
                return View();
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        [Authentication]
        public IActionResult themluong(string id, string manv)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            DateTime month = DateTime.Parse(id);
            Nhanvien nv = db.Nhanviens.Include(p => p.MaChucVuNavigation).FirstOrDefault(p => p.MaNv == manv);
            var luong = db.Luongs.ToList();
            ViewBag.luong = luong;
            ViewBag.Message1 = month;
            return View(nv);
        }
        [HttpPost]
        [Authentication]
        public ActionResult themluongnv(int tenluong, string manv, DateTime thang, int nc, decimal thuong, decimal phat)
        {
            Luong luong = db.Luongs.Find(tenluong);
            LuongNv luongNv = new LuongNv();
            luongNv.MaLuong = tenluong;
            luongNv.MaNv = manv;
            luongNv.Thang = thang;
            luongNv.NgayCong = nc;
            luongNv.Thuong = thuong;
            luongNv.Phat = phat;
            luongNv.LuongTong = thuong - phat + luong.PhuCap + luong.LuongCoBan * nc;
            db.LuongNvs.Add(luongNv);
            db.SaveChanges();
            string month = Convert.ToString(thang);
            return RedirectToAction("taobangluong", new { thang = month });
        }
        [Authentication]
        public ActionResult xoaluongnv(int id, string thang)
        {
            var luongnv = db.LuongNvs.Find(id);
            db.LuongNvs.Remove(luongnv);
            db.SaveChanges();
            return RedirectToAction("bangluong", new { thang = thang });
        }
        [Authentication]
        public ActionResult xoatatca(string id)
        {
            DateTime month;
            if (DateTime.TryParse(id, out month))
            {
                var luongnv = db.LuongNvs.Where(p => p.Thang == month).ToList();
                foreach (var i in luongnv)
                {
                    db.LuongNvs.Remove(i);
                }
                db.SaveChanges();
                return RedirectToAction("bangluong");
            }
            else return RedirectToAction("bangluong");
        }
        [HttpGet]
        [Authentication]
        public IActionResult xemthongtinluong(string searchString)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            var luong = db.Luongs.Select(p => p);
            if (!string.IsNullOrEmpty(searchString))
            {
                luong = luong.Where(e => e.TenMaLuong.Contains(searchString));
            }
            ViewBag.SearchString = searchString;
            return View(luong.ToList());
        }
        [Authentication]
        public ActionResult xoaluong(int id)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            var luongnv = db.LuongNvs.Where(p => p.MaLuong == id).ToList();
            if (luongnv.Any())
            {
                foreach (var lnv in luongnv)
                {
                    db.LuongNvs.Remove(lnv);
                }
                db.SaveChanges();
            }
            Luong luong = db.Luongs.Find(id);
            db.Luongs.Remove(luong);
            db.SaveChanges();
            return RedirectToAction("xemthongtinluong");
        }
        [Authentication]
        public IActionResult themmaluong()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            return View();
        }
        [HttpPost]
        [Authentication]
        public ActionResult themmaluongmoi(string name, decimal salary, decimal allowance)
        {
            Luong luong = new Luong();
            luong.TenMaLuong = name;
            luong.LuongCoBan = salary;
            luong.PhuCap = allowance;
            db.Luongs.Add(luong);
            db.SaveChanges();
            return RedirectToAction("xemthongtinluong", "Ketoan");
        }
        [Authentication]
        public IActionResult chinhsua(int id)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            var luong = db.Luongs.Find(id);
            return View(luong);
        }
        [HttpPost]
        [Authentication]
        public ActionResult chinhsualuong(int maluong, string name, decimal salary, decimal allowance)
        {
            var luongUp = db.Luongs.FirstOrDefault(e => e.MaLuong == maluong);
            if (luongUp != null)
            {
                luongUp.TenMaLuong = name;
                luongUp.LuongCoBan = salary;
                luongUp.PhuCap = allowance;
                db.SaveChanges();
                return RedirectToAction("xemthongtinluong", "Ketoan");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        [Authentication]
        public IActionResult chinhsualuongnv(int id)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            var luong = db.Luongs.ToList();
            ViewBag.luong = luong;
            var luongnv = db.LuongNvs.Find(id);
            var nv = db.Nhanviens.Include(p => p.MaChucVuNavigation).FirstOrDefault(p => p.MaNv == luongnv.MaNv);
            ViewBag.nv = nv;
            return View(luongnv);
        }
        [HttpPost]
        [Authentication]
        public ActionResult chinhsualuongnv1(int maluong, int tenluong, int nc, decimal thuong, decimal phat)
        {
            var luong = db.Luongs.Find(tenluong);
            var luongnv = db.LuongNvs.Find(maluong);
            luongnv.MaLuong = tenluong;
            luongnv.NgayCong = nc;
            luongnv.Thuong = thuong;
            luongnv.Phat = phat;
            luongnv.LuongTong = thuong - phat + luong.PhuCap + luong.LuongCoBan * nc;
            db.LuongNvs.Update(luongnv);
            db.SaveChanges();
            return RedirectToAction("bangluong", new { thang = Convert.ToString(luongnv.Thang) });
        }
    }
}

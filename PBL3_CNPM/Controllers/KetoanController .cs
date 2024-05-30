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
    public class KetoanController : Controller
    {
        QuanlynhanvienkhachsanContext db = new QuanlynhanvienkhachsanContext();
        [Authentication]
        public IActionResult Trangchuketoan()
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            DateTime now = DateTime.Now;
            int thang = now.Month;
            ViewBag.thang = thang;
            decimal? thuong = 0, phat = 0, pc = 0, lcb = 0;
            var luongnv = db.LuongNvs.Where(p => p.Thang == thang).Select(p => new { p.Thuong, p.Phat, p.MaLuongNavigation.PhuCap, p.MaLuongNavigation.LuongCoBan });
            foreach (var i in luongnv.ToList())
            {
                thuong += i.Thuong;
                phat += i.Phat;
                pc += i.PhuCap;
                lcb += i.LuongCoBan;
            }
            ViewBag.thuong = thuong;
            ViewBag.phat = phat;
            ViewBag.pc = pc;
            ViewBag.lcb = lcb;
            return View();
        }
        [HttpGet]
        [Authentication]
        public IActionResult bangluong(int thang)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message1 = currentUserId;
            if (thang == 0) thang = 1;
            ViewBag.Message2 = thang;
            var luong = db.LuongNvs.Where(p => p.Thang == thang).Select(p => new { p.MaLuongNv ,p.Thang , p.MaNvNavigation.MaNv, p.MaNvNavigation.TenNhanVien,
            p.MaLuongNavigation.LuongCoBan, p.MaLuongNavigation.PhuCap, p.NgayCong, p.Thuong, p.Phat, p.LuongTong} );
            return View(luong.ToList());
        }
        [HttpGet]
        [Authentication]
        public IActionResult taobangluong(int thang)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message1 = currentUserId;
            if (thang == 0) thang = 1;
            ViewBag.Message2 = thang;
            var nv = db.Nhanviens.Where(nv => !nv.LuongNvs.Any(l => l.Thang == thang) && nv.MaPhanQuyen == "103").Select(p => new { p.MaNv,p.TenNhanVien,p.MaChucVuNavigation.ChucVu}).ToList();
            return View(nv.ToList());
        }
        [HttpGet]
        [Authentication]
        public IActionResult themluong(int id, string manv)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            ViewBag.Message = currentUserId;
            if (id == 0) id = 1;
            Nhanvien nv = db.Nhanviens.Include(p => p.MaChucVuNavigation).FirstOrDefault(p => p.MaNv == manv);
            var luong = db.Luongs.ToList();
            ViewBag.luong = luong;
            ViewBag.Message1 = id;
            return View(nv);
        }
        [HttpPost]
        [Authentication]
        public ActionResult themluongnv(int tenluong, string manv, int thang, int nc, decimal thuong, decimal phat)
        {
            Luong luong = db.Luongs.Find(tenluong);
            LuongNv luongNv = new LuongNv();
            luongNv.MaLuong = tenluong;
            luongNv.MaNv = manv;
            luongNv.Thang = thang;
            luongNv.NgayCong = nc;
            luongNv.Thuong = thuong;
            luongNv.Phat = phat;
            luongNv.LuongTong = thuong + phat + luong.PhuCap + luong.LuongCoBan;
            db.LuongNvs.Add(luongNv);
            db.SaveChanges();
            return RedirectToAction("taobangluong");
        }
        [Authentication]
        public ActionResult xoaluongnv(int id)
        {
            var luongnv = db.LuongNvs.Find(id);
            db.LuongNvs.Remove(luongnv);
            db.SaveChanges();
            return RedirectToAction("bangluong");
        }
        [Authentication]
        public ActionResult xoatatca(int id)
        {
            var luongnv = db.LuongNvs.Where(p => p.Thang == id).ToList();
            foreach (var i in luongnv)
            {
                db.Remove(i);  
            }
            db.SaveChanges();
            return RedirectToAction("bangluong");
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
        public ActionResult chinhsualuong(int maluong,string name, decimal salary, decimal allowance)
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
            luongnv.LuongTong = thuong + phat + luong.PhuCap + luong.LuongCoBan;
            db.LuongNvs.Update(luongnv);
            db.SaveChanges();
            return RedirectToAction("bangluong");
        }
    } 
}

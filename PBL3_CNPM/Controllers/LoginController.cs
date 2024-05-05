﻿using Microsoft.AspNetCore.Mvc;
using PBL3_CNPM.Models;
using Microsoft.AspNetCore.Http;

namespace PBL3CNPM.Controllers
{
	public class LoginController : Controller
	{
		QuanlynhanvienkhachsanContext db = new QuanlynhanvienkhachsanContext();
		[HttpGet]
		public IActionResult Login()
		{
			if (HttpContext.Session.GetString("MaNv") == null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}

		}
		[HttpPost]
        [HttpPost]
        public IActionResult Login(Nhanvien user, Phanquyen quyen)
        {
            if (HttpContext.Session.GetString("MaNv") == null)
            {
                var u = db.Nhanviens.FirstOrDefault(x => x.MaNv.Equals(user.MaNv) && x.Password.Equals(user.Password) && x.MaPhanQuyen.Equals(user.MaPhanQuyen));
                if (u != null)
                {
                    HttpContext.Session.SetString("MaNv", u.MaNv.ToString());
                    var role = db.Phanquyens.FirstOrDefault(q => q.MaPhanQuyen == u.MaPhanQuyen);
                    if (role != null)
                    {
                        if (role.PhanQuyen.Equals("Quản lý"))
                        {
                            return RedirectToAction("Phanquyenquanly", "Login");
                        }
                        else if (role.PhanQuyen.Equals("Kế toán"))
                        {
                            return RedirectToAction("Phanquyenketoan", "Login");
                        }
                        else if (role.PhanQuyen.Equals("Nhân viên"))
                        {
                            return RedirectToAction("Index", "Nhanvien");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Nhanvien");
                    }
                }
            }
            return View();
        }
        public IActionResult Phanquyenquanly()
        {
            return View();
        }
        public IActionResult Phanquyenketoan()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("MaNv");
            return RedirectToAction("Login", "Login");
        }



    }
}
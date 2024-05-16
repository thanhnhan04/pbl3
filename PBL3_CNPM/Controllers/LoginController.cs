using Microsoft.AspNetCore.Mvc;
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
				return RedirectToAction("login", "login");
			}

		}
		[HttpPost]
       
        public IActionResult Login(Nhanvien user, Phanquyen quyen)
        {
            if (HttpContext.Session.GetString("MaNv") == null)
            {
                var u = db.Nhanviens.FirstOrDefault(x => x.MaNv.Equals(user.MaNv) && x.Password.Equals(user.Password));
                if (u != null)
                {
                    HttpContext.Session.SetString("MaNv", u.MaNv.ToString());
                    var role = db.Phanquyens.FirstOrDefault(q => q.MaPhanQuyen == u.MaPhanQuyen);
                    if (role != null)
                    {
                        if (role.PhanQuyen.Equals("Quản lý"))
                        {
                            return RedirectToAction("quanlyhoso", "Quanly");
                        }
                        else if (role.PhanQuyen.Equals("Kế toán"))
                        {
                            return RedirectToAction("Trangchuketoan", "Ketoan");
                        }
                        else if (role.PhanQuyen.Equals("Nhân viên"))
                        {
                            return RedirectToAction("thongtin", "Nhanvien");
                        }
                    }
                    else
                    {
                        return RedirectToAction("thongtin", "Nhanvien");
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

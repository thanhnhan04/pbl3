using Microsoft.AspNetCore.Mvc;
using PBL3_CNPM.Models;
using Microsoft.AspNetCore.Http;
using PBL3_CNPM.Controllers;
using Microsoft.Data.SqlClient;

namespace PBL3CNPM.Controllers
{
    public class LoginController : Controller
    {
        QuanlynhanvienkhachsanContext db = new QuanlynhanvienkhachsanContext();
        private readonly ILogger<LoginController> _logger;
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

        public IActionResult Login(Nhanvien user)
        {
            try
            {
                // Attempt to find the user in the database
                var u = db.Nhanviens.FirstOrDefault(x => x.MaNv.Equals(user.MaNv) && x.Password.Equals(user.Password));
                if (u != null)
                {
                    // Set session variables for logged-in user
                    if (u.TrangThai == true)
                    {
                        HttpContext.Session.SetString("MaNv", u.MaNv.ToString());
                        var role = db.Phanquyens.FirstOrDefault(q => q.MaPhanQuyen == u.MaPhanQuyen);

                        if (role != null)
                        {
                            switch (role.PhanQuyen)
                            {
                                case "Quản lý":
                                    return RedirectToAction("quanlyhoso", "Quanly");
                                case "Kế toán":
                                    return RedirectToAction("Trangchuketoan", "Ketoan");
                                case "Nhân viên":
                                    return RedirectToAction("thongtin", "Nhanvien");
                                default:
                                    TempData["ErrorMessage"] = "Vai trò người dùng không xác định.";
                                    return RedirectToAction("login");
                            }
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Không tìm thấy vai trò của người dùng.";
                            return RedirectToAction("login");
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Tài khoản đã bị khóa.";
                        return RedirectToAction("login");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Mã NV hoặc mật khẩu không đúng.";
                    return RedirectToAction("login");
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError($"Lỗi cơ sở dữ liệu: {ex.Message}");
                TempData["ErrorMessage"] = "Lỗi cơ sở dữ liệu. Vui lòng thử lại sau.";
                return RedirectToAction("login");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi không xác định: {ex.Message}");
                TempData["ErrorMessage"] = "Đã xảy ra lỗi. Vui lòng thử lại sau.";
                return RedirectToAction("login");
            }
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("MaNv");
            return RedirectToAction("Login", "Login");
        }



    }
}

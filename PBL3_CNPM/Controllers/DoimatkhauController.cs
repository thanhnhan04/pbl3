using Microsoft.AspNetCore.Mvc;
using PBL3_CNPM.Models;

namespace PBL3_CNPM.Controllers
{
    public class DoimatkhauController : Controller
    {
        private readonly QuanlynhanvienkhachsanContext _masterContext;
        private readonly ILogger<DoimatkhauController> _logger;
        public DoimatkhauController(ILogger<DoimatkhauController> logger)
        {
            _masterContext = new();
            _logger = logger;
        }
        QuanlynhanvienkhachsanContext db = new QuanlynhanvienkhachsanContext();
      
        [HttpGet]

        public ActionResult Doimatkhau(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Doimatkhau(string Password, string matkhaumoi, string matkhaumoi2)
        {
            string currentUserId = HttpContext.Session.GetString("MaNv");
            if (string.IsNullOrEmpty(currentUserId))
            {
                return RedirectToAction("Login", "Login");
            }
            Nhanvien nv = db.Nhanviens.Find(currentUserId);
            if (nv != null && nv.Password == Password)
            {
                if (matkhaumoi != matkhaumoi2)
                {
                    ViewBag.ErrorMessage = "Mật khẩu mới và mật khẩu nhập lại không trùng khớp.";
                    return View();
                }
               
                nv.Password = matkhaumoi;
                db.SaveChanges();

                
                HttpContext.Session.SetString("Password", matkhaumoi);

              
                
                ViewBag.SuccessMessage = "Đổi mật khẩu thành công";
                return View("Doimatkhau");
            }
            else
            {
                ViewBag.ErrorMessage = "Mật khẩu cũ không chính xác.";
                return View();
            }
        }



    }
}

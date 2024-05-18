using Microsoft.AspNetCore.Mvc;
using PBL3_CNPM.Models.Authentication;
using PBL3_CNPM.Models;

namespace PBL3_CNPM.Controllers
{
    public class KetoanController : Controller
    {
        QuanlynhanvienkhachsanContext db = new QuanlynhanvienkhachsanContext();
        [Authentication]
        public IActionResult Trangchuketoan()
        {

            return View();
        }
        public IActionResult xemthongtinluong()
        {
            var luong = db.Luongs.ToList();
            return View(luong);
        }
        public IActionResult bangluong()
        {
            return View();
        }
        
    }
}

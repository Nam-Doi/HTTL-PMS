using Microsoft.AspNetCore.Mvc;

namespace PMS.Controllers
{
    public class PhuTroController : Controller
    {
        // View chính
        public IActionResult Index()
        {
            return View();
        }

        // Action AJAX render lại bảng (trả về partial view khác nhau)
        public IActionResult RenderPhuTro(string loai, int thang, int nam)
        {
            switch (loai)
            {
                case "DienThoai":
                    return PartialView("_PhuTroDienThoai");  // Views/PhuTro/_PhuTroDienThoai.cshtml

                case "CDPhi":
                    return PartialView("_PhuTroCDPhi");      // Views/PhuTro/_PhuTroCDPhi.cshtml

                case "TNCN":
                    return PartialView("_PhuTroTNCN");       // Views/PhuTro/_PhuTroTNCN.cshtml

                default:
                    return Content("Loại phụ trợ không hợp lệ.");
            }
        }
    }
}

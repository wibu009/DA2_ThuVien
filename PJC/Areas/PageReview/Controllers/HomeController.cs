using ASS_QLTV_API.Services;
using Microsoft.AspNetCore.Mvc;
using PJC.Models;

namespace PJC.Areas.PageReview.Controllers
{
    [Area("PageReview")]
    public class HomeController : Controller
    {
        private APIServices _services;

        public HomeController()
        {
            _services = new APIServices();
        }

        public IActionResult Index()
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;

            //int a = context.DemSach();
            //int b = context.DemDocGia();
            //int c = context.DemPhieuMuon();
            //int d = context.DemPhieuTra();
            //int e = context.DemPhieuChuaTra();
            //double f = context.DemDoanhThu();
            //ViewBag.SoLuongSach = a;
            //ViewBag.SoLuongDocGia = b;
            //ViewBag.SoLuongPhieuMuon = c;
            //ViewBag.SoLuongPhieuTra = d;
            //ViewBag.SoLuongPhieuChuaTra = e;
            //ViewBag.DoanhThu = f;
            return View();
        }
    }
}

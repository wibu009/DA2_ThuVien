using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASS_QLTV_API.Models;
using ASS_QLTV_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PJC.Models;
using Sach = ASS_QLTV_API.Models.Sach;

namespace PJC.Controllers
{
    public class ThongKeController : Controller
    {
        private APIServices _services;
        private int? _demSach;
        private int? _demDocGia;
        private int? _demPhieuMuon;
        private int? _demPhieuTra;
        private int? _demPhieuChuaTra;
        private double? _demDoanhThu;

        public ThongKeController()
        {
            _services = new APIServices();
            _demSach = JsonConvert
                .DeserializeObject<List<Sach>>(_services.GetDataFromAPI("https://localhost:44301/", "api/Saches"))
                .ToList().Count;
            _demDocGia = JsonConvert
                .DeserializeObject<List<Docgium>>(_services.GetDataFromAPI("https://localhost:44301/", "api/Docgiums"))
                .ToList().Count;
            _demPhieuMuon = JsonConvert
                .DeserializeObject<List<Phieumuon>>(_services.GetDataFromAPI("https://localhost:44301/", "api/Phieumuons"))
                .ToList().Count;
            _demPhieuTra = JsonConvert
                .DeserializeObject<List<Ctpm>>(_services.GetDataFromAPI("https://localhost:44301/", "api/Ctpms"))
                .Where(c => c.NgayTra != null).ToList().Count;
            _demPhieuChuaTra = JsonConvert
                .DeserializeObject<List<Ctpm>>(_services.GetDataFromAPI("https://localhost:44301/", "api/Ctpms"))
                .Where(c => c.NgayTra == null).ToList().Count;
            _demDoanhThu = JsonConvert
                .DeserializeObject<List<Ctpm>>(_services.GetDataFromAPI("https://localhost:44301/", "api/Ctpms"))
                .ToList().Sum(c => c.TienPhat);
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

            ViewBag.SoLuongSach = _demSach;
            ViewBag.SoLuongDocGia = _demDocGia;
            ViewBag.SoLuongPhieuMuon = _demPhieuMuon;
            ViewBag.SoLuongPhieuTra = _demPhieuTra;
            ViewBag.SoLuongPhieuChuaTra = _demPhieuChuaTra;
            ViewBag.DoanhThu = _demDoanhThu;
            return View();
        }
        public IActionResult Index1()
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

            ViewBag.SoLuongSach = _demSach;
            ViewBag.SoLuongDocGia = _demDocGia;
            ViewBag.SoLuongPhieuMuon = _demPhieuMuon;
            ViewBag.SoLuongPhieuTra = _demPhieuTra;
            ViewBag.SoLuongPhieuChuaTra = _demPhieuChuaTra;
            ViewBag.DoanhThu = _demDoanhThu;
            return View(JsonConvert
                .DeserializeObject<List<Sach>>(_services.GetDataFromAPI("https://localhost:44301/", "api/Saches"))
                .ToList());
        }
        public IActionResult Index2()
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

            ViewBag.SoLuongSach = _demSach;
            ViewBag.SoLuongDocGia = _demDocGia;
            ViewBag.SoLuongPhieuMuon = _demPhieuMuon;
            ViewBag.SoLuongPhieuTra = _demPhieuTra;
            ViewBag.SoLuongPhieuChuaTra = _demPhieuChuaTra;
            ViewBag.DoanhThu = _demDoanhThu;
            return View(JsonConvert
                .DeserializeObject<List<Docgium>>(_services.GetDataFromAPI("https://localhost:44301/", "api/Docgiums"))
                .ToList());
        }
        public IActionResult Index3()
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

            ViewBag.SoLuongSach = _demSach;
            ViewBag.SoLuongDocGia = _demDocGia;
            ViewBag.SoLuongPhieuMuon = _demPhieuMuon;
            ViewBag.SoLuongPhieuTra = _demPhieuTra;
            ViewBag.SoLuongPhieuChuaTra = _demPhieuChuaTra;
            ViewBag.SoLuongPhieuChuaTra = _demPhieuChuaTra;
            ViewBag.DoanhThu = _demDoanhThu;

            return View(JsonConvert
                .DeserializeObject<List<Phieumuon>>(_services.GetDataFromAPI("https://localhost:44301/", "api/Phieumuons"))
                .ToList());
        }
        public IActionResult Index4()
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

            ViewBag.SoLuongSach = _demSach;
            ViewBag.SoLuongDocGia = _demDocGia;
            ViewBag.SoLuongPhieuMuon = _demPhieuMuon;
            ViewBag.SoLuongPhieuTra = _demPhieuTra;
            ViewBag.SoLuongPhieuChuaTra = _demPhieuChuaTra;
            ViewBag.DoanhThu = _demDoanhThu;
            return View(JsonConvert
                .DeserializeObject<List<Ctpm>>(_services.GetDataFromAPI("https://localhost:44301/", "api/Ctpms"))
                .Where(c => c.NgayTra != null).ToList());
        }
        public IActionResult Index5()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
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

            ViewBag.SoLuongSach = _demSach;
            ViewBag.SoLuongDocGia = _demDocGia;
            ViewBag.SoLuongPhieuMuon = _demPhieuMuon;
            ViewBag.SoLuongPhieuTra = _demPhieuTra;
            ViewBag.SoLuongPhieuChuaTra = _demPhieuChuaTra;
            ViewBag.DoanhThu = _demDoanhThu;

            return View(JsonConvert
                .DeserializeObject<List<Ctpm>>(_services.GetDataFromAPI("https://localhost:44301/", "api/Ctpms"))
                .Where(c => c.NgayTra == null).ToList());
        }
        public IActionResult Index6()
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

            ViewBag.SoLuongSach = _demSach;
            ViewBag.SoLuongDocGia = _demDocGia;
            ViewBag.SoLuongPhieuMuon = _demPhieuMuon;
            ViewBag.SoLuongPhieuTra = _demPhieuTra;
            ViewBag.SoLuongPhieuChuaTra = _demPhieuChuaTra;
            ViewBag.DoanhThu = _demDoanhThu;
            return View(JsonConvert
                .DeserializeObject<List<Ctpm>>(_services.GetDataFromAPI("https://localhost:44301/", "api/Ctpms"))
                .Where(c => c.TienPhat > 0).ToList());
        }
    }
}

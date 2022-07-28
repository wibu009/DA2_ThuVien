using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASS_QLTV_API.Models;
using ASS_QLTV_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using PJC.Models;
using Sach = PJC.Models.Sach;

namespace PJC.Controllers
{
   //[Authorize]
    public class PhieuTraController : Controller
    {
        private APIServices _services;

        public PhieuTraController()
        {
            _services = new APIServices();
        }

        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //return View(context.GetPhieuTra());
            var data = _services.GetDataFromAPI("https://localhost:44301/", "api/Ctpms");
            List<ASS_QLTV_API.Models.Ctpm> ctpmList =
                JsonConvert.DeserializeObject<List<ASS_QLTV_API.Models.Ctpm>>(data);
            return View(ctpmList.Where(c => c.NgayTra != null));
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            ViewBag.mapm = HttpContext.Session.GetString("mapm");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ctpm pt)
        {
            int count;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            ViewBag.mapm = HttpContext.Session.GetString("mapm");
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.CreatePhieuTra(pt);

            pt.MaCtpm = pt.MaPm + pt.MaSach;
            pt.TienPhat = 0;
            var pm = JsonConvert.DeserializeObject<Phieumuon>(
                _services.GetDataFromAPIById("https://localhost:44301/", "api/Phieumuons", pt.MaPm));
            pt.User = pm.User;
            count = _services.PostCtPhieuMuon("https://localhost:44301/api/Ctpms", pt);
            if (count == 100)
            {
                TempData["result"] = "Mỗi sách chỉ được mượn 1 quyển";
            }
            else if (count == 1)
            {
                pm.SoLuongMuon += 1;
                _services.PutPhieuMuon("https://localhost:44301/api/Phieumuons", pm);
                TempData["result"] = "Thêm sách thành công";
            }
            else
            {
                TempData["result"] = "Thêm sách không thành công";
            }
            return Redirect("~/PhieuTra/Create");
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //CTPM pt = context.GetPhieuTraByMaPM(id);
            //ViewData.Model = pt;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Ctpms", id);
            Ctpm ctpm = JsonConvert.DeserializeObject<Ctpm>(data);
            ViewData.Model = ctpm;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Ctpm pt)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.UpdatePhieuTra(pt);
            count = _services.PutCtPhieuMuon("https://localhost:44301/api/Ctpms", pt);
            if (count > 0)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["result"] = "Cập nhật không thành công";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //CTPM pt = context.GetPhieuTraByMaPM(id,masach);
            //ViewData.Model = pt;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Ctpms", id);
            Ctpm ctpm = JsonConvert.DeserializeObject<Ctpm>(data);
            ViewData.Model = ctpm;
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Ctpm pt)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.DeletePhieuTra(pt);
            count = _services.DeleteData("https://localhost:44301/", "api/Ctpms", pt.MaCtpm);
            if (count > 0)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["result"] = "Xóa không thành công";
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //CTPM pt = context.GetPhieuTraByMaPM(id,masach);
            //ViewData.Model = pt;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Ctpms", id);
            Ctpm ctpm = JsonConvert.DeserializeObject<Ctpm>(data);
            ViewData.Model = ctpm;
            return View();
        }
        [HttpGet]
        public IActionResult TraSach()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //return View(context.GetPhieuChuaTra());
            var data = _services.GetDataFromAPI("https://localhost:44301/", "api/Ctpms");
            List<ASS_QLTV_API.Models.Ctpm> ctpmList =
                JsonConvert.DeserializeObject<List<ASS_QLTV_API.Models.Ctpm>>(data);
            return View(ctpmList.Where(c => c.NgayTra == null));

        }
        [HttpGet]
        public IActionResult EditTraSach(string id)
        {
            ViewBag.user = HttpContext.Session.GetString("user");
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //PhieuMuonInCTPM pt = context.GetPhieuChuaTraById(id, masach);
            //ViewData.Model = pt;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Ctpms", id);
            Ctpm ct = JsonConvert.DeserializeObject<Ctpm>(data);
            ViewData.Model = ct;
            return View();
        }
        [HttpPost]
        public IActionResult EditTraSach(Ctpm pt)
        {
            ViewBag.user = HttpContext.Session.GetString("user");
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.UpdatePhieuTra(pt);
            //count1 = context.UpdateTienPhat(pt);
            var data = JsonConvert.DeserializeObject<List<Phieumuon>>(new APIServices().GetDataFromAPI("https://localhost:44301/", "api/Phieumuons"));
            var pm = data.FirstOrDefault(p => p.MaPm == pt.MaPm);

            DateTime ngaytra = pt.NgayTra ?? DateTime.Now; ;
            DateTime ngayhentra = pm.NgayHenTra;
            TimeSpan Time = ngaytra - ngayhentra;
            int day = Time.Days;
            int? hieu = pt.TinhTrangSach - pt.TinhTrangTra;
            double? tienphat = 0;
            if (hieu > 0 && day > 0)
            {
                tienphat = hieu * 1000 + day * 5000;
                pt.TienPhat = tienphat;
                _services.PutCtPhieuMuon("https://localhost:44301/api/Ctpms", pt);
                TempData["result"] = "Bạn làm hao tổn sách: " + (hieu/pt.TinhTrangSach * 100) + "%. Và bạn trễ hạn: " + day + " ngày. Bạn bị phạt: " + (hieu * 1000 + day * 5000);
            }
            if (hieu > 0 && day <= 0)
            {
                tienphat = hieu * 1000;
                pt.TienPhat = tienphat;
                _services.PutCtPhieuMuon("https://localhost:44301/api/Ctpms", pt);
                TempData["result"] = "Bạn làm hao tổn sách: " + (hieu / pt.TinhTrangSach * 100) + "%. Bạn bị phạt: " + hieu * 1000 + " VND";
            }
            if (hieu == 0 && day > 0)
            {
                tienphat = day * 5000;
                pt.TienPhat = tienphat;
                _services.PutCtPhieuMuon("https://localhost:44301/api/Ctpms", pt);
                TempData["result"] = "Bạn trễ hạn " + day + " ngày. Bạn bị phạt: " + day * 5000;
            }
            if( pt.TinhTrangTra == 0)
            {
                ASS_QLTV_API.Models.Sach s =
                    JsonConvert.DeserializeObject<ASS_QLTV_API.Models.Sach>(
                        _services.GetDataFromAPIById("https://localhost:44301/", "api/Saches", pt.MaSach));
                Docgium dg =
                    JsonConvert.DeserializeObject<Docgium>(_services.GetDataFromAPIById("https://localhost:44301/",
                        "api/Docgiums", pm.MaDg));

                tienphat = s.GiaTien;
                pt.TienPhat = tienphat;
                dg.MatSach += 1;

                _services.PutDG("https://localhost:44301/api/Docgiums", dg);
                _services.PutCtPhieuMuon("https://localhost:44301/api/Ctpms", pt);
                TempData["result"] = "Bạn làm mất sách.Tiền Sách: " + tienphat;
            }
            if( hieu == 0 && day <=0)
            {
                pt.TienPhat = 0;
                _services.PutCtPhieuMuon("https://localhost:44301/api/Ctpms", pt);
                TempData["result"] = "Trả sách thành công";
            }

            return RedirectToAction("Index");

        }
        public IActionResult CTPM(string id)
        {
            ViewBag.mapm = id;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //return View(context.GetPhieuTraByMaPM(id));
            List<Ctpm> clist =
                JsonConvert.DeserializeObject<List<Ctpm>>(_services.GetDataFromAPI("https://localhost:44301/",
                    "api/Ctpms"));
            return View(clist.Where(c => c.MaPm == id).ToList());
        }
    }
}

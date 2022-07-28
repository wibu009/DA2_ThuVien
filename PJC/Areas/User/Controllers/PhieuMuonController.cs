using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASS_QLTV_API.Models;
using ASS_QLTV_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using PJC.Models;

namespace PJC.Areas.User.Controllers
{
    //[Authorize]
    [Area("User")]
    public class PhieuMuonController : Controller
    {
        private APIServices _services;

        public PhieuMuonController()
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
            //return View(context.GetPhieuMuon());
            var data = _services.GetDataFromAPI("https://localhost:44301/", "api/Phieumuons");
            List<ASS_QLTV_API.Models.Phieumuon> pmList =
                JsonConvert.DeserializeObject<List<ASS_QLTV_API.Models.Phieumuon>>(data);
            return View(pmList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.sessionv= HttpContext.Session.GetString("user");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Phieumuon pm)
        {
            int count;
            HttpContext.Session.SetString("mapm", pm.MaPm);
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.CreatePhieuMuon(pm);
            count = _services.PostPhieuMuon("https://localhost:44301/api/Phieumuons", pm);
            if (count == 100)
            {
                TempData["result"] = "Bạn làm mất sách 3 lần. Không được mượn nữa!";
                return Redirect("~/PhieuMuon/Index");
            }
            else if (count > 0)
            {
                TempData["result"] = "Thêm mới phiếu mượn thành công";
            }
            else
            {
                TempData["result"] = "Thêm mới phiếu mượn không thành công";
            }
            return Redirect("~/User/PhieuTra/Create");
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //PhieuMuon pm = context.GetPhieuMuonByMaPM(id);
            //ViewData.Model = pm;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Phieumuons", id);
            Phieumuon pm = JsonConvert.DeserializeObject<Phieumuon>(data);
            ViewData.Model = pm;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Phieumuon pm)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.UpdatePhieuMuon(pm);
            count = _services.PutPhieuMuon("https://localhost:44301/api/Phieumuons", pm);

            if (count > 0)
            {
                TempData["result"] = "Cập nhật thành công";
                return Redirect("~/User/PhieuMuon/Index");
            }
            else
            {
                TempData["result"] = "Cập nhật không thành công";
                return Redirect("~/User/PhieuMuon/Index");
            }
        }
        
        [HttpPost]
        public IActionResult EditSoLuong(string id)
        {
            string a= HttpContext.Session.GetString("mapm");
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.UpdateSoLuongSach(a);
            Phieumuon pm = JsonConvert.DeserializeObject<Phieumuon>(_services.GetDataFromAPIById("https://localhost:44301/", "api/Phieumuons", a));
            pm.SoLuongMuon += 0;
            count = _services.PutPhieuMuon("https://localhost:44301/api/Phieumuons", pm);
            if (count > 0)
            {
                TempData["result"] = "Cập nhật số lượng sách mượn thành công";
                return Redirect("~/User/PhieuMuon/Index");
            }
            else
            {
                TempData["result"] = "Cập nhật số lượng sách mượn không thành công";
                return Redirect("~/User/PhieuMuon/Index");
            }
        }
        public IActionResult Delete(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //PhieuMuon pm= context.GetPhieuMuonByMaPM(id);
            //ViewData.Model = pm;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Phieumuons", id);
            Phieumuon pm = JsonConvert.DeserializeObject<Phieumuon>(data);
            ViewData.Model = pm;
            return View();
        }
        [HttpPost]
        public IActionResult Delete(PhieuMuon pm)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.DeletePhieuMuon(pm);
            count = _services.DeleteData("https://localhost:44301/", "api/Phieumuons", pm.MaPM);
            if (count > 0)
            {
                TempData["result"] = "Xóa phiếu mượn  thành công";
                return Redirect("~/User/PhieuMuon/Index");
            }
            else
            {
                TempData["result"] = "Xóa phiếu mượn không thành công";
                return Redirect("~/User/PhieuMuon/Index");
            }
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //PhieuMuon pm = context.GetPhieuMuonByMaPM(id);
            //ViewData.Model = pm;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Phieumuons", id);
            Phieumuon pm = JsonConvert.DeserializeObject<Phieumuon>(data);
            ViewData.Model = pm;
            return View();
        }
    }
}

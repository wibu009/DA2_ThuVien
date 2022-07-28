using System.Collections.Generic;
using ASS_QLTV_API.Models;
using ASS_QLTV_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PJC.Models;

namespace PJC.Areas.User.Controllers
{
    [Area("User")]

    public class DocGiaController : Controller
    {
        private APIServices _services;

        public DocGiaController()
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
            //return View(context.GetDocGia());
            var data = _services.GetDataFromAPI("https://localhost:44301/", "api/Docgiums");
            List<ASS_QLTV_API.Models.Docgium> dgList =
                JsonConvert.DeserializeObject<List<ASS_QLTV_API.Models.Docgium>>(data);
            return View(dgList);
        }
        [HttpGet]
       // [Area("User")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
       // [Area("User")]
        public IActionResult Create(Docgium dg)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.CreateDocGia(dg);
            count = _services.PostDocGia("https://localhost:44301/api/Docgiums", dg);
            if (count > 0)
            {
                TempData["result"] = "Thêm mới độc giả thành công";
            }
            else
            {
                TempData["result"] = "Thêm mới độc giả không thành công";
            }
            return Redirect("~/User/DocGia/Index");
        }
        [HttpGet]
      //  [Area("User")]
        public IActionResult Edit(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //DocGia dg = context.GetDocGiaByMaDG(id);
            //ViewData.Model = dg;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Docgiums", id);
            Docgium dg = JsonConvert.DeserializeObject<Docgium>(data);
            ViewData.Model = dg;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Docgium dg)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.UpdateDocGia(dg);
            count = _services.PutDG("https://localhost:44301/api/Docgiums", dg);
            if (count > 0)
            {
                TempData["result"] = "Cập nhật thành công";
                return Redirect("~/User/DocGia/Index");
            }
            else
            {
                TempData["result"] = "Cập nhật không thành công";
                return Redirect("~/User/DocGia/Index");
            }
        }
        [HttpGet]
       // [Area("User")]
        public IActionResult Delete(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //DocGia dg = context.GetDocGiaByMaDG(id);
            //ViewData.Model = dg;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Docgiums", id);
            Docgium dg = JsonConvert.DeserializeObject<Docgium>(data);
            ViewData.Model = dg;
            return View();
        }
        [HttpPost]
      //  [Area("User")]
        public IActionResult Delete(Docgium dg)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.DeleteDocGia(dg);
            count = _services.DeleteData("https://localhost:44301/", "api/Docgiums", dg.MaDg);
            if (count > 0)
            {
                TempData["result"] = "Xóa độc giả  thành công";
                return Redirect("~/User/DocGia/Index");
            }
            else
            {
                TempData["result"] = "Xóa độc giả không thành công";
                return Redirect("~/User/DocGia/Index");
            }
        }
       // [Area("User")]
        public IActionResult Detail(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //DocGia s = context.GetDocGiaByMaDG(id);
            //ViewData.Model = s;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Docgiums", id);
            Docgium dg = JsonConvert.DeserializeObject<Docgium>(data);
            ViewData.Model = dg;
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using ASS_QLTV_API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PJC.Models;

namespace PJC.Areas.User
{
    [Area("User")]
    public class ProductController : Controller
    {
        private StoreContext context;
        private APIServices _services;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IWebHostEnvironment hostEnvironment)
        {
            _services = new APIServices();
            _hostEnvironment = hostEnvironment;
        }

        void setDBContext()
        {
            if (context == null)
                context = HttpContext.RequestServices.GetService(typeof(StoreContext)) as StoreContext;
        }
        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //return View(context.GetSanPham());
            var data = _services.GetDataFromAPI("https://localhost:44301/", "api/Saches");
            List<ASS_QLTV_API.Models.Sach> sachList =
                JsonConvert.DeserializeObject<List<ASS_QLTV_API.Models.Sach>>(data);
            return View(sachList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ASS_QLTV_API.Models.Sach sach)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.CreateSach(sach);
            string wwwrootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(sach.ImageFile.FileName);
            string extension = Path.GetExtension(sach.ImageFile.FileName);
            sach.ImageUrl = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwrootPath + "/image/sach/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                sach.ImageFile.CopyToAsync(fileStream);
            }

            count = _services.PostSach("https://localhost:44301/api/Saches", sach);

            if (count > 0)
            {
                TempData["result"] = "Thêm mới sách thành công";
            }
            else
            {
                TempData["result"] = "Thêm mới sách không thành công";
            }
            return Redirect("~/User/Product/Index");
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //Sach s = context.GetSachByMa(id);
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Saches", id);
            ASS_QLTV_API.Models.Sach sach = JsonConvert.DeserializeObject<ASS_QLTV_API.Models.Sach>(data);
            ViewData.Model = sach;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Sach s)
        {
            int count;
            StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            count = context.UpdateProduct(s);
            if (count > 0)
            {
                TempData["result"] = "Cập nhật thành công";
                return Redirect("~/User/Product/Index");
            }
            else
            {
                TempData["result"] = "Cập nhật không thành công";
                return Redirect("~/User/Product/Index");
            }
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //Sach s = context.GetSachByMa(id);
            //ViewData.Model = s;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Saches", id);
            ASS_QLTV_API.Models.Sach sach = JsonConvert.DeserializeObject<ASS_QLTV_API.Models.Sach>(data);
            ViewData.Model = sach;
            return View(sach);
        }
        [HttpPost]
        public IActionResult Delete(ASS_QLTV_API.Models.Sach s)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.DeleteSach(s);
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Saches", s.MaSach);
            ASS_QLTV_API.Models.Sach sach = JsonConvert.DeserializeObject<ASS_QLTV_API.Models.Sach>(data);

            if (sach != null)
            {
                var imagePath = Path.Combine(_hostEnvironment.WebRootPath + sach.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);
            }

            count = _services.DeleteData("https://localhost:44301/", "api/Saches", s.MaSach);

            if (count > 0)
            {
                TempData["result"] = "Xóa sách  thành công";
                return Redirect("~/User/Product/Index");
            }
            else
            {
                TempData["result"] = "Xóa sách không thành công";
                return Redirect("~/User/Product/Index");
            }
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Saches", id);
            ASS_QLTV_API.Models.Sach sach = JsonConvert.DeserializeObject<ASS_QLTV_API.Models.Sach>(data);
            ViewData.Model = sach;
            return View();
        }
    }
}

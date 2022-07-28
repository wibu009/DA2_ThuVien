using System;
using System.Collections.Generic;
using System.IO;
using ASS_QLTV_API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PJC.Models;
using Sach = ASS_QLTV_API.Models.Sach;

namespace PJC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly APIServices _services;
        private StoreContext context;

        public ProductController(IWebHostEnvironment hostEnvironment)
        {
            _services = new APIServices();
            _hostEnvironment = hostEnvironment;
        }

        private void setDBContext()
        {
            if (context == null)
                context = HttpContext.RequestServices.GetService(typeof(StoreContext)) as StoreContext;
        }

        public IActionResult Index()
        {
            if (TempData["result"] != null) ViewBag.SuccessMsg = TempData["result"];
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //return View(context.GetSanPham());
            var data = _services.GetDataFromAPI("https://localhost:44301/", "api/Saches");
            var productList = JsonConvert.DeserializeObject<List<Sach>>(data);
            return View(productList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sach sach)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.CreateSach(sach);

            var wwwrootPath = _hostEnvironment.WebRootPath;
            var fileName = Path.GetFileNameWithoutExtension(sach.ImageFile.FileName);
            var extension = Path.GetExtension(sach.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            var path = Path.Combine(wwwrootPath + "\\img\\sach\\", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                sach.ImageFile.CopyTo(fileStream);
            }

            sach.ImageUrl = "/img/sach/" + fileName;

            count = _services.PostSach("https://localhost:44301/api/Saches", sach);

            if (count > 0)
                TempData["result"] = "Thêm mới sách thành công";
            else
                TempData["result"] = "Thêm mới sách không thành công";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //Sach s = context.GetSachByMa(id);
            //ViewData.Model = s;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Saches", id);
            var sach = JsonConvert.DeserializeObject<Sach>(data);
            ViewData.Model = sach;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Sach sach)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.UpdateProduct(s);
            //delete image from wwwroot
            if (sach.ImageFile == null)
            {
                Sach s = JsonConvert.DeserializeObject<Sach>(
                    _services.GetDataFromAPIById("https://localhost:44301/", "api/Saches", sach.MaSach));
                sach.ImageUrl = s.ImageUrl;
            }
            else
            {
                if (sach.ImageUrl != null)
                {
                    var imagePath = Path.Combine(_hostEnvironment.WebRootPath + sach.ImageUrl);
                    if (System.IO.File.Exists(imagePath))
                        System.IO.File.Delete(imagePath);
                }

                var wwwrootPath = _hostEnvironment.WebRootPath;
                var fileName = Path.GetFileNameWithoutExtension(sach.ImageFile.FileName);
                var extension = Path.GetExtension(sach.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                var path = Path.Combine(wwwrootPath + "\\img\\sach\\", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    sach.ImageFile.CopyTo(fileStream);
                }

                sach.ImageUrl = "/img/sach/" + fileName;
            }


            count = _services.PutSach("https://localhost:44301/api/Saches", sach);
            if (count > 0)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }

            TempData["result"] = "Cập nhật không thành công";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //Sach s = context.GetSachByMa(id);
            //ViewData.Model = s;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Saches", id);
            var sach = JsonConvert.DeserializeObject<Sach>(data);
            ViewData.Model = sach;
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Sach s)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.DeleteSach(s);
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Saches", s.MaSach);
            var sach = JsonConvert.DeserializeObject<Sach>(data);

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
                return RedirectToAction(nameof(Index));
            }

            TempData["result"] = "Xóa sách không thành công";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //Sach s = context.GetSachByMa(id);
            //ViewData.Model = s;
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Saches", id);
            var sach = JsonConvert.DeserializeObject<Sach>(data);
            ViewData.Model = sach;
            return View();
        }
    }
}
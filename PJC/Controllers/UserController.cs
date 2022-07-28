using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASS_QLTV_API.Models;
using ASS_QLTV_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PJC.Models;
using Renci.SshNet.Messages;
using PJC.Controllers;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace PJC.Controllers
{
   // [Authorize]
    public class UserController : Controller
    {
        
        private StoreContext context;
        APIServices _services = new APIServices();

        void setDBContext()
        {
            if (context == null)
                context = HttpContext.RequestServices.GetService(typeof(StoreContext)) as StoreContext;
        }

        public UserController()
        {
            _services = new APIServices();
        }

        public IActionResult Index(string Keyword)
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            string data = _services.GetDataFromAPI("https://localhost:44301/", "api/Taikhoans");
            List<Taikhoan> accList = JsonConvert.DeserializeObject<List<Taikhoan>>(data);
            return View(accList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Taikhoan tk)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.CreateUser(tk);
            count = _services.PostUser("https://localhost:44301/api/Taikhoans", tk);
            
            if (count > 0)
            {
                TempData["result"] = "Thêm mới người dùng thành công";            
            }
            else
            {
                TempData["result"] = "Thêm mới người dùng không thành công";              
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //TaiKhoan tk = context.GetTaiKhoanByUser(id);
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Taikhoans", id);
            Taikhoan tk = JsonConvert.DeserializeObject<Taikhoan>(data);
            ViewData.Model = tk;
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Taikhoan tk)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.UpdateUser(tk);
            count = _services.PutUser("https://localhost:44301/api/Taikhoans", tk);

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
            //TaiKhoan tk = context.GetTaiKhoanByUser(id);
            var data = _services.GetDataFromAPIById("https://localhost:44301/", "api/Taikhoans", id);
            Taikhoan tk = JsonConvert.DeserializeObject<Taikhoan>(data);
            ViewData.Model = tk;
            return View();
        }
        [HttpPost]
        public IActionResult Delete(TaiKhoan tk)
        {

            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //count = context.DeleteUser(tk);
            count = _services.DeleteData("https://localhost:44301/", "api/Taikhoans", tk.User);

            if (count > 0)
            {
                TempData["result"] = "Xóa người dùng thành công";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["result"] = "Xóa người dùng không thành công";
                //return View();
                return RedirectToAction(nameof(Index));
            }
        }
    
    }
}

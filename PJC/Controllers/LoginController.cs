using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASS_QLTV_API.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using PJC.Models;
using Renci.SshNet;

namespace PJC.Controllers
{
   

    public class LoginController : Controller
    {
        private APIServices _services;

        public LoginController()
        {
            _services = new APIServices();
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(string user,string password)
        {
           
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            //int kq = context.Login(user, password);
            int kq = _services.Login(user, password);
            TempData["userlogin"] = user;
            HttpContext.Session.SetString("user", user);

            if (kq == 1)
            {
                return RedirectToAction("Index","Home");
                //return RedirectToAction("Index", "Home");
            }    
            else if(kq == -1)
            {
                TempData["result"] = "Đăng nhập không thành công";
                return RedirectToAction("Index", "Login");
            }
            return Redirect("~/User/Home/Index");
        }
     
    }
}

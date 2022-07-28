using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASS_QLTV_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PJC.Models;

namespace PJC.Areas.User
{
    [Area("User")]
    public class DMKController : Controller
    {
        private APIServices _services;

        public DMKController()
        {
            _services = new APIServices();
        }

        [HttpGet]
        public IActionResult DoiMK()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            ViewBag.user = HttpContext.Session.GetString("user");
            return View();
        }
        [HttpPost]
        public IActionResult DoiMK(DoiMK d)
        {
            int count;
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(PJC.Models.StoreContext)) as StoreContext;
            ViewBag.user = HttpContext.Session.GetString("user");
            if (String.CompareOrdinal(d.PassWord, d.PassWordConfirm) == 0)
            {
                 //count = context.DoiMK(d);
                 count = _services.ChangePass(d.User, d.PassWord);
                if (count > 0)
                {
                    TempData["result"] = "Đổi mật khẩu thành công";
                    return View();
                    //return Redirect("~/User/DMK/DoiMK");
                }
                else
                {
                    TempData["result"] = "Đổi mật khẩu không thành công";
                    //return RedirectToAction("Index", "Home");
                    return Redirect("~/User/DMK/DoiMK");
                }
            }
            else
            {
                TempData["result"] = "Mật khẩu không khớp";
                return View();
            }

        }
    }
}

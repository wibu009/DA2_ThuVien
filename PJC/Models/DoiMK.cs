using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJC.Models
{
    public class DoiMK
    {
        private string passWord;
        private string user;
        private string passWordConfirm;
        [Display(Name = "Tài khoản:")]
        public string User { get => user; set => user = value; }
        [Display(Name ="Mật khẩu mới:")]
        public string PassWord { get => passWord; set => passWord = value; }
        [Display(Name = "Nhập mật khẩu mới:")]
        public string PassWordConfirm { get => passWordConfirm; set => passWordConfirm = value; }

    }
}

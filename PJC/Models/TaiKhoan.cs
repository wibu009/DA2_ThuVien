using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJC.Models
{
    public class TaiKhoan
    {
        private string user;
        private string passWord;
        private int phanQuyen;
        private string tenND;
        private string sDT;
        private string cMND;
        [Display(Name ="Tài khoản đăng nhập: ")]
        public string User { get => user; set => user = value; }
        [Display(Name = "Mật khẩu: ")]
        public string PassWord { get => passWord; set => passWord = value; }
        [Display(Name = "Phân quyền: ")]
        public int PhanQuyen { get => phanQuyen; set => phanQuyen = value; }
        [Display(Name = "Tên người dùng: ")]
        public string TenND { get => tenND; set => tenND = value; }
        [Display(Name = "Số điện thoại: ")]
        public string SDT { get => sDT; set => sDT = value; }
        [Display(Name = "CMND/Thẻ Căn Cước: ")]
        public string CMND { get => cMND; set => cMND = value; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJC.Models
{
    public class DocGia
    {
        private string maDG;
        private string tenDG;
        private string sDT;
        private string diaChi;
        private string gioiTinh;
        private int matSach;
        [Display(Name ="Mã độc giả: ")]
        public string MaDG { get => maDG; set =>maDG = value; }
        [Display(Name = "Tên độc giả: ")]
        public string TenDG { get => tenDG; set => tenDG= value; }
        [Display(Name = "Số điện thoại: ")]
        public string SDT { get => sDT; set => sDT= value; }
        [Display(Name = "Địa chỉ: ")]
        public string DiaChi { get => diaChi; set => diaChi= value; }
        [Display(Name = "Giới tính: ")]
        public string GioiTinh { get => gioiTinh; set => gioiTinh= value; }
        [Display(Name = "Số lần mất sách: ")]
        public int MatSach { get => matSach; set => matSach= value; }



    }
}

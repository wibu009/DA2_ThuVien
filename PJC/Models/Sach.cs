using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJC.Models
{
    public class Sach
    {
        private string maSach;
        private string tenSach;
        private string tenTG;
        private string nhaXB;
        private string theLoai;
        private int soLuong;
        private string imageUrl;
        private double giaTien;
        private string mieuTa;
        [Display(Name = "Mã sách: ")]
        public string MaSach { get => maSach; set => maSach = value; }
        [Display(Name = "Tên sách: ")]
        public string TenSach { get => tenSach; set => tenSach = value; }
        [Display(Name = "Tên tác giả: ")]
        public string TenTG { get => tenTG; set => tenTG = value; }
        [Display(Name = "Nhà xuất bản: ")]
        public string NhaXB { get => nhaXB; set => nhaXB = value; }
        [Display(Name = "Thể loại: ")]
        public string TheLoai { get => theLoai; set => theLoai = value; }
        [Display(Name = "Số lượng: ")]
        public int SoLuong { get => soLuong; set => soLuong = value; }
        [Display(Name = "Giá tiền: ")]
        public double GiaTien { get => giaTien; set => giaTien = value; }
        [Display(Name = "Hình ảnh: ")]
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        [Display(Name = "Miêu tả: ")]
        public string MieuTa { get => mieuTa; set => mieuTa = value; }

        public Sach()
        {

        }
        public Sach(string masach,string tensach,string tentg,string nhaxb,string theloai,int soluong,double giatien)
        {
            this.maSach = masach;
            this.tenSach = tensach;
            this.tenTG = tentg;
            this.nhaXB = nhaxb;
            this.theLoai = theloai;
            this.soLuong = soluong;
            this.giaTien = giatien;

        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJC.Models
{
    public class ThongKePhieuChuaTra
    {
        private string maPM;
        private string maSach;
        private int tinhTrangSach;
        private DateTime ngayHenTra;
        private string user;
        private string maDG;
        [Display(Name = "Mã phiếu mượn:")]
        public string MaPM { get => maPM; set => maPM = value; }
        [Display(Name = "Mã độc giả:")]
        public string MaDG { get => maDG; set => maDG = value; }
        [Display(Name = "Mã sách:")]
        public string MaSach { get => maSach; set => maSach = value; }

        [Display(Name = "Ngày Hẹn Trả:")]
        [DataType(DataType.Date)]
        public DateTime NgayHenTra { get => ngayHenTra; set => ngayHenTra = value; }

        [Display(Name = "Tình trạng mượn:")]
        public int TinhTrangSach { get => tinhTrangSach; set => tinhTrangSach = value; }
        [Display(Name = "Thủ thư cho mượn:")]
        public string User { get => user; set => user = value; }

  
    }
}

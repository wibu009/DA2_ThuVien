using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PJC.Models
{
    public class PhieuMuon
    {
        private string maPM;
        private string maDG;
        private DateTime ngayMuon;
        private DateTime ngayHenTra;
        private int soLuongMuon;
        private string user;
        [Display(Name = "Mã phiếu mượn:")]
        public string MaPM { get => maPM; set => maPM = value; }
        [Display(Name = "Mã độc giả:")]
        public string MaDG { get => maDG; set => maDG = value; }
        [Display(Name = "Ngày Mượn:")]
        [DataType(DataType.Date)]
        public DateTime NgayMuon { get => ngayMuon; set => ngayMuon = value; }
        [Display(Name = "Ngày Hẹn Trả:")]
        [DataType(DataType.Date)]
        public DateTime NgayHenTra { get => ngayHenTra; set => ngayHenTra = value; }
        [Display(Name = "Số lượng mượn:")]

        public int SoLuongMuon { get => soLuongMuon; set => soLuongMuon = value; }
        [Display(Name = "Thủ thư cho mượn:")]
        public string User { get => user; set => user = value; }


    }
}

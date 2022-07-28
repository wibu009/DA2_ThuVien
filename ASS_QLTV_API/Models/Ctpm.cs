

#nullable disable

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ASS_QLTV_API.Models
{
    public partial class Ctpm
    {
        public string MaCtpm { get; set; }
        public string MaPm { get; set; }
        public string MaSach { get; set; }
        public DateTime? NgayTra { get; set; }
        public int TinhTrangSach { get; set; }
        public int? TinhTrangTra { get; set; }
        public string User { get; set; }
        public string GhiChu { get; set; }
        public double? TienPhat { get; set; }

        [JsonIgnore]
        public virtual Phieumuon MaPmNavigation { get; set; }
        [JsonIgnore]
        public virtual Sach MaSachNavigation { get; set; }
        [JsonIgnore]
        public virtual Taikhoan UserNavigation { get; set; }
    }
}

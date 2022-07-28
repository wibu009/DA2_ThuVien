

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ASS_QLTV_API.Models
{
    public partial class Phieumuon
    {
        public Phieumuon()
        {
            Ctpms = new HashSet<Ctpm>();
        }

        public string MaPm { get; set; }
        public string MaDg { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayHenTra { get; set; }
        public int SoLuongMuon { get; set; }
        public string User { get; set; }

        [JsonIgnore]
        public virtual Docgium MaDgNavigation { get; set; }
        [JsonIgnore]
        public virtual Taikhoan UserNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Ctpm> Ctpms { get; set; }
    }
}

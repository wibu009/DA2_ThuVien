

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ASS_QLTV_API.Models
{
    public partial class Taikhoan
    {
        public Taikhoan()
        {
            Ctpms = new HashSet<Ctpm>();
            Phieumuons = new HashSet<Phieumuon>();
        }

        public string User { get; set; }
        public string Password { get; set; }
        public int PhanQuyen { get; set; }
        public string TenNd { get; set; }
        public string Sdt { get; set; }
        public string Cmnd { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ctpm> Ctpms { get; set; }
        [JsonIgnore]
        public virtual ICollection<Phieumuon> Phieumuons { get; set; }
    }
}

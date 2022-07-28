

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ASS_QLTV_API.Models
{
    public partial class Docgium
    {
        public Docgium()
        {
            Phieumuons = new HashSet<Phieumuon>();
        }

        public string MaDg { get; set; }
        public string TenDg { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public int MatSach { get; set; }

        [JsonIgnore]
        public virtual ICollection<Phieumuon> Phieumuons { get; set; }
    }
}

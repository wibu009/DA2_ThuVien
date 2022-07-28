

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace ASS_QLTV_API.Models
{
    public partial class Sach
    {
        public Sach()
        {
            Ctpms = new HashSet<Ctpm>();
        }

        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TenTg { get; set; }
        public string NhaXb { get; set; }
        public string TheLoai { get; set; }
        public int SoLuong { get; set; }
        public double GiaTien { get; set; }
        public string ImageUrl { get; set; }
        [JsonIgnore]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string MieuTa { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ctpm> Ctpms { get; set; }
    }
}

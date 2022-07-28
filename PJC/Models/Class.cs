using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJC.Models
{
    public class Class
    {
        public int SoSach { get; set; }     
        public int SoDocGia { get; set; }
        public int SoPhieuMuon { get; set; }
        public int SoPhieuTra { get; set; }

        public DateTime MemberSince { get; set; }
        public string TopBranchName { get; set; }
        public string TopBranhImg { get; set; }
    }
}

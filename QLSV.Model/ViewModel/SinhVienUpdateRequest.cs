using QLSV.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Model
{
    public class SinhVienUpdateRequest
    {
        public string TenSinhVien { get; set; }
        public int Tuoi { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public bool GioiTinh { get; set; }
        public Lop Lop { get; set; }
    }
}

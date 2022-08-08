using QLSV.Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Model
{
    public class SinhVienCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(250)]
        [Required(ErrorMessage = "Hãy nhập tên sinh viên")]
        public string TenSinhVien { get; set; }
        [Required(ErrorMessage = "Hãy nhập tuổi sinh viên")]
        public int Tuoi { get; set; }
        [Required(ErrorMessage = "Hãy nhập địa chỉ sinh viên")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Hãy nhập email sinh viên")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Hãy nhập SDT sinh viên")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Hãy nhập giới tính sinh viên")]
        public bool GioiTinh { get; set; }
        public Lop Lop { get; set; }
    }
}

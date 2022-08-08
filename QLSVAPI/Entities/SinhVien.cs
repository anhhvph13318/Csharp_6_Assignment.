using QLSVAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Model.Data
{
    public class SinhVien
    {
        public Guid Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string TenSinhVien { get; set; }
        public int Tuoi { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public bool GioiTinh { get; set; }
        public Lop Lop { get; set; }
        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}

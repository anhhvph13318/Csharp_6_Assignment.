using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Model
{
    public class DiemCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public int HocKy { get; set; }
        [Required]
        public float DiemGiuaKy { get; set; }
        [Required]
        public float DiemCuoiKy { get; set; }
        [Required]
        public float DiemTongKet { get; set; }
    }
}

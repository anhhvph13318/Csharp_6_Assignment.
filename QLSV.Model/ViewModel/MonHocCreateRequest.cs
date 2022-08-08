using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Model
{
    public class MonHocCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Hãy nhập tên môn học")]
        public string TenMonHoc { get; set; }
        [Required(ErrorMessage = "Hãy nhập số tín chỉ")]
        public int SoTinChi { get; set; }
    }
}

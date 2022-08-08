using QLSV.Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Model
{
    public class LopCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Hãy nhập tên lớp")]
        public string TenLop { get; set; }
        public Nganh Nganh { get; set; }
    }
}

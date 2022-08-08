using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Model
{
    public class NganhCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Hãy nhập tên ngành")]
        public string TenNganh { get; set; }
    }
}

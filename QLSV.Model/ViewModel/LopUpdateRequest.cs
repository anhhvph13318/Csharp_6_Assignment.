using QLSV.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Model
{
    public class LopUpdateRequest
    {
        public Guid Id { get; set; }
        public string TenLop { get; set; }
        public Nganh Nganh { get; set; }
    }
}

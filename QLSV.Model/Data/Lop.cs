using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Model.Data
{
    public class Lop
    {
        public Guid Id { get; set; }
        public string TenLop { get; set; }
        public Nganh Nganh { get; set; }
    }
}

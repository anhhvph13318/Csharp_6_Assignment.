using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Model
{
    public class MonHocUpdateRequest
    {
        public Guid Id { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTinChi { get; set; }
    }
}

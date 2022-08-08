using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Model
{
    public class DiemDTO
    {
        public Guid Id { get; set; }
        public int HocKy { get; set; }
        public float DiemGiuaKy { get; set; }
        public float DiemCuoiKy { get; set; }
        public float DiemTongKet { get; set; }
    }
}

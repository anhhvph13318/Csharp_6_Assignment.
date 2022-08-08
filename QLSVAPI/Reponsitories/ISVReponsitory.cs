using QLSV.Model;
using QLSV.Model.Data;
using QLSV.Model.Search;
using QLSVAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Reponsitories
{
    public interface ISVReponsitory
    {
        Task<IEnumerable<SinhVien>> GetSVList(SinhVienSearch sinhVienSearch);
        Task<SinhVien> Create(SinhVien sinhVien);
        Task<SinhVien> Update(SinhVien sinhVien);
        Task<bool> Delete(Guid id);
        Task<SinhVien> GetById(Guid id);
    }
}

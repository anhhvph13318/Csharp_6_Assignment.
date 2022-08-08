using QLSV.Model.Data;
using QLSV.Model.Search;
using QLSVAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Reponsitories
{
    public interface IDiemReponsitory
    {
        Task<IEnumerable<Diem>> GetDiemList(DiemSearch diemSearch);
        Task<Diem> Create(Diem diem);
        Task<Diem> Update(Diem diem);
        Task<Diem> Delete(Diem diem);
        Task<Diem> GetById(Guid id);
    }
}

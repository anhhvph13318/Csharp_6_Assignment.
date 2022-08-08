using QLSV.Model.Data;
using QLSV.Model.Search;
using QLSVAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Reponsitories
{
    public interface ILopReponsitory
    {
        Task<IEnumerable<Lop>> GetLopList(LopSearch lopSearch);
        Task<Lop> Create(Lop lop);
        Task<Lop> Update(Lop lop);
        Task<Lop> Delete(Lop lop);
        Task<Lop> GetById(Guid id);
    }
}

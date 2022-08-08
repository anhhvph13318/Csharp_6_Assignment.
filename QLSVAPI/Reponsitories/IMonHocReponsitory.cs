using QLSV.Model.Data;
using QLSV.Model.Search;
using QLSVAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Reponsitories
{
    public interface IMonHocReponsitory
    {
        Task<IEnumerable<MonHoc>> GetMonHocList(MonHocSearch monHocSearch);
        Task<MonHoc> Create(MonHoc monHoc);
        Task<MonHoc> Update(MonHoc monHoc);
        Task<MonHoc> Delete(MonHoc monHoc);
        Task<MonHoc> GetById(Guid id);
    }
}

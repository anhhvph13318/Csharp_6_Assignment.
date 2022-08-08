using QLSV.Model.Data;
using QLSV.Model.Search;
using QLSVAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Reponsitories
{
    public interface INganhReponsitory
    {
        Task<IEnumerable<Nganh>> GetNganhList(NganhSearch nganhSearch);
        Task<Nganh> Create(Nganh nganh);
        Task<Nganh> Update(Nganh nganh);
        Task<Nganh> Delete(Nganh nganh);
        Task<Nganh> GetById(Guid id);
    }
}

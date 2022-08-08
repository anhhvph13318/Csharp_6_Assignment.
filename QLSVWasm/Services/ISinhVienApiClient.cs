using QLSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVWasm.Services
{
    public interface ISinhVienApiClient
    {
        Task<List<SinhVienDTO>> GetSinhViens();

        Task<SinhVienDTO> GetSVDetail(string id);

        Task<bool> CreateSV(SinhVienCreateRequest request);
        Task<bool> UpdateSV(Guid id, SinhVienUpdateRequest request);
        Task<bool> Delete(Guid id);

      
    }
}

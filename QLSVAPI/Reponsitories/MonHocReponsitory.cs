using Microsoft.EntityFrameworkCore;
using QLSV.Model.Data;
using QLSV.Model.Search;
using QLSVAPI.Data;
using QLSVAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Reponsitories
{
    public class MonHocReponsitory : IMonHocReponsitory
    {
        private readonly QLSVDbContext _context;

        public MonHocReponsitory(QLSVDbContext context)
        {
            _context = context;
        }

        public async Task<MonHoc> Create(MonHoc monHoc)
        {
            await _context.MonHocs.AddAsync(monHoc);
            await _context.SaveChangesAsync();
            return monHoc;
        }

        public async Task<MonHoc> Delete(MonHoc monHoc)
        {
            _context.MonHocs.Remove(monHoc);
            await _context.SaveChangesAsync();
            return monHoc;
        }

        public async Task<MonHoc> GetById(Guid id)
        {
            return await _context.MonHocs.FindAsync(id);
        }

        public async Task<IEnumerable<MonHoc>> GetMonHocList(MonHocSearch monHocSearch)
        {
            var query = _context.MonHocs.AsQueryable();
            if (!string.IsNullOrEmpty(monHocSearch.TenMonHoc))
            {
                query = query.Where(x => x.TenMonHoc.Contains(monHocSearch.TenMonHoc));
            }
            return await query.ToListAsync();
        }

        public async Task<MonHoc> Update(MonHoc monHoc)
        {
            _context.MonHocs.Update(monHoc);
            await _context.SaveChangesAsync();
            return monHoc;
        }
    }
}

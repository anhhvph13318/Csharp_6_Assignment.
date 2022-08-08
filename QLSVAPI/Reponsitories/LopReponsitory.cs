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
    public class LopReponsitory : ILopReponsitory
    {
        private readonly QLSVDbContext _context;

        public LopReponsitory(QLSVDbContext context)
        {
            _context = context;
        }
        public async Task<Lop> Create(Lop lop)
        {
            await _context.Lops.AddAsync(lop);
            await _context.SaveChangesAsync();
            return lop;
        }

        public async Task<Lop> Delete(Lop lop)
        {
            _context.Lops.Remove(lop);
            await _context.SaveChangesAsync();
            return lop;
        }

        public async Task<Lop> GetById(Guid id)
        {
            return await _context.Lops.FindAsync(id);
        }

        public async Task<IEnumerable<Lop>> GetLopList(LopSearch lopSearch)
        {
            var query = _context.Lops.AsQueryable();
            if (!string.IsNullOrEmpty(lopSearch.TenLop))
            {
                query = query.Where(x => x.TenLop.Contains(lopSearch.TenLop));
            }
            return await query.ToListAsync();
        }

        public async Task<Lop> Update(Lop lop)
        {
            _context.Lops.Update(lop);
            await _context.SaveChangesAsync();
            return lop;
        }
    }
}

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
    public class NganhReponsitory : INganhReponsitory
    {
        private readonly QLSVDbContext _context;

        public NganhReponsitory(QLSVDbContext context)
        {
            _context = context;
        }
        public async Task<Nganh> Create(Nganh nganh)
        {
            await _context.Nganhs.AddAsync(nganh);
            await _context.SaveChangesAsync();
            return nganh;
        }

        public async Task<Nganh> Delete(Nganh nganh)
        {
            _context.Nganhs.Remove(nganh);
            await _context.SaveChangesAsync();
            return nganh;
        }

        public async Task<Nganh> GetById(Guid id)
        {
            return await _context.Nganhs.FindAsync(id);
        }

        public async Task<IEnumerable<Nganh>> GetNganhList(NganhSearch nganhSearch)
        {
            var query = _context.Nganhs.AsQueryable();
            if (!string.IsNullOrEmpty(nganhSearch.TenNganh))
            {
                query = query.Where(x => x.TenNganh.Contains(nganhSearch.TenNganh));
            }
            return await query.ToListAsync();
        }

        public async Task<Nganh> Update(Nganh nganh)
        {
            _context.Nganhs.Update(nganh);
            await _context.SaveChangesAsync();
            return nganh;
        }
    }
}

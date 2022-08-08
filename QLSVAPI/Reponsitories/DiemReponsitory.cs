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
    public class DiemReponsitory : IDiemReponsitory
    {
        private readonly QLSVDbContext _context;

        public DiemReponsitory(QLSVDbContext context)
        {
            _context = context;
        }

        public async Task<Diem> Create(Diem diem)
        {
            await _context.Diems.AddAsync(diem);
            await _context.SaveChangesAsync();
            return diem;
        }

        public async Task<Diem> Delete(Diem diem)
        {
            _context.Diems.Remove(diem);
            await _context.SaveChangesAsync();
            return diem;
        }

        public async Task<Diem> GetById(Guid id)
        {
            return await _context.Diems.FindAsync(id);
        }

        public async Task<IEnumerable<Diem>> GetDiemList(DiemSearch diemSearch)
        {
            var query = _context.Diems.AsQueryable();
            if (diemSearch.HocKy != 0)
            {
                query = query.Where(x => x.HocKy.ToString().Contains(diemSearch.HocKy.ToString()));
            }
            return await query.ToListAsync();
        }

        public async Task<Diem> Update(Diem diem)
        {
            _context.Diems.Update(diem);
            await _context.SaveChangesAsync();
            return diem;
        }
    }
}

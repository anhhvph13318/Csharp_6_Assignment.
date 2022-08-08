using Microsoft.EntityFrameworkCore;
using QLSV.Model;
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
    public class SVReponsitory : ISVReponsitory
    {
        private readonly QLSVDbContext _context;

        public SVReponsitory(QLSVDbContext context)
        {
            _context = context;
        }

        public async Task<SinhVien> Create(SinhVien sinhVien)
        {
            await _context.SinhViens.AddAsync(sinhVien);
            await _context.SaveChangesAsync();
            return sinhVien;
        }

        public async Task<bool> Delete(Guid id)
        {
            var sinhvien = _context.SinhViens.FirstOrDefault(c=>c.Id == id);
            _context.SinhViens.Remove(sinhvien);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<SinhVien> GetById(Guid id)
        {
            return await _context.SinhViens.FindAsync(id);
        }

        public async Task<IEnumerable<SinhVien>> GetSVList(SinhVienSearch sinhVienSearch)
        {
            var query = _context.SinhViens.Include(x=>x.User).AsQueryable();
            if(!string.IsNullOrEmpty(sinhVienSearch.TenSinhVien))
            {
                query = query.Where(x => x.TenSinhVien.Contains(sinhVienSearch.TenSinhVien));
            }
            if (sinhVienSearch.UserId.HasValue)
            {
                query = query.Where(x => x.UserId.Value == sinhVienSearch.UserId.Value);
            }
            return await query.ToListAsync();
        }

        public async Task<SinhVien> Update(SinhVien sinhVien)
        {
            _context.SinhViens.Update(sinhVien);
            await _context.SaveChangesAsync();
            return sinhVien;
        }
    }
}

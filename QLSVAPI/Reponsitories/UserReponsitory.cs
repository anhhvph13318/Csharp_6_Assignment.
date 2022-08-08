using Microsoft.EntityFrameworkCore;
using QLSV.Model;
using QLSVAPI.Data;
using QLSVAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Reponsitories
{
    public class UserReponsitory : IUserReponsitory
    {
        private readonly QLSVDbContext _context;

        public UserReponsitory(QLSVDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }
    }
}

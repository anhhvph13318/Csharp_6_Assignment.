using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLSV.Model.Data;
using QLSVAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Data
{
    public class QLSVDbContext : IdentityDbContext<User,Role,Guid>
    {
        public QLSVDbContext(DbContextOptions<QLSVDbContext> options) : base(options)
        {

        }

        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<Nganh> Nganhs { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<Diem> Diems { get; set; }
    }
}

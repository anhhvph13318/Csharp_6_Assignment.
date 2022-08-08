using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using QLSVAPI.Entities;
using QLSV.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Data
{
    public class SinhVienDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async Task SeedAsync(QLSVDbContext context, ILogger<SinhVienDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    HoTen = "Việt Anh",
                    Email = "admin@gmail.com",
                    PhoneNumber = "0123456789",
                    UserName = "admin",                 
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123");
                context.Users.Add(user);
            }

            if (!context.Nganhs.Any())
            {
                context.Nganhs.Add(new Nganh()
                {
                    Id = Guid.NewGuid(),
                    TenNganh = "Ứng Dụng Phần Mềm",
                });
            }

            if (!context.MonHocs.Any())
            {
                context.MonHocs.Add(new MonHoc()
                {
                    Id = Guid.NewGuid(),
                    TenMonHoc = "C#6",
                    SoTinChi = 3,
                });
            }

            if (!context.Lops.Any())
            {
                context.Lops.Add(new Lop()
                {
                    Id = Guid.NewGuid(),
                    TenLop = "IT16301",
                    Nganh = context.Nganhs.FirstOrDefault(x=>x.TenNganh == "Ứng Dụng Phần Mềm")
                });
            }

            if (!context.SinhViens.Any())
            {
                context.SinhViens.Add(new SinhVien()
                {
                    Id = Guid.NewGuid(),
                    TenSinhVien = "Hồ Việt Anh",
                    Tuoi = 20,
                    DiaChi = "Bắc Giang",
                    Email = "anhhvph13318@gmail.com",
                    SDT = "0987632512",
                    GioiTinh = true,
                    Lop = context.Lops.FirstOrDefault(x=>x.TenLop == "IT16301"),
                    User = context.Users.FirstOrDefault(x=>x.HoTen == "Việt Anh")
                });
            }

            if (!context.Diems.Any())
            {
                context.Diems.Add(new Diem()
                {
                    Id = Guid.NewGuid(),
                    HocKy = 6,
                    DiemGiuaKy = 8,
                    DiemCuoiKy = 10,
                    DiemTongKet = 9,
                    SinhVien = context.SinhViens.FirstOrDefault(x=>x.TenSinhVien == "Hồ Việt Anh"),
                    MonHoc = context.MonHocs.FirstOrDefault(x=>x.TenMonHoc == "C#6"),
                });
            }

            await context.SaveChangesAsync();
        }
    }
}

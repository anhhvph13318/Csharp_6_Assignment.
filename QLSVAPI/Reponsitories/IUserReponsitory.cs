using QLSV.Model;
using QLSVAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Reponsitories
{
    public interface IUserReponsitory
    {
        Task<List<User>> GetUserList();
    }
}

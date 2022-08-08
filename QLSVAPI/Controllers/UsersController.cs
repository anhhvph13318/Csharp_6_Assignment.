using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSV.Model;
using QLSVAPI.Reponsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserReponsitory _userReponsitory;

        public UsersController(IUserReponsitory userReponsitory)
        {
            _userReponsitory = userReponsitory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userReponsitory.GetUserList();
            var userDTOs = users.Select(x => new UserDTO()
            {
                Id = x.Id,
                HoTen = x.HoTen
            });
            return Ok(userDTOs);
        }
    }
}

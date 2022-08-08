using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSV.Model;
using QLSV.Model.Data;
using QLSV.Model.Search;
using QLSVAPI.Reponsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemsController : ControllerBase
    {
        private readonly IDiemReponsitory _diemReponsitory;

        public DiemsController(IDiemReponsitory diemReponsitory)
        {
            _diemReponsitory = diemReponsitory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DiemSearch diemSearch)
        {
            var diems = await _diemReponsitory.GetDiemList(diemSearch);
            var diemDTOs = diems.Select(x => new DiemDTO()
            {
                Id = x.Id,
                HocKy = x.HocKy,
                DiemGiuaKy = x.DiemGiuaKy,
                DiemCuoiKy = x.DiemCuoiKy,
                DiemTongKet = x.DiemTongKet,
            });
            return Ok(diemDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]DiemCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var diem = await _diemReponsitory.Create(new Diem()
            {
                Id = request.Id,
                HocKy = request.HocKy,
                DiemGiuaKy = request.DiemGiuaKy,
                DiemCuoiKy = request.DiemCuoiKy,
                DiemTongKet = request.DiemTongKet,
            });
            return CreatedAtAction(nameof(GetById), new { id = diem.Id }, diem);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]DiemUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var diemFromDB = await _diemReponsitory.GetById(id);
            if (diemFromDB == null)
            {
                return NotFound($"{id} không tồn tại");
            }
            diemFromDB.HocKy = request.HocKy;
            diemFromDB.DiemGiuaKy = request.DiemGiuaKy;
            diemFromDB.DiemCuoiKy = request.DiemCuoiKy;
            diemFromDB.DiemTongKet = request.DiemTongKet;

            var diems = await _diemReponsitory.Update(diemFromDB);
            return Ok(new DiemDTO()
            {
                Id = diems.Id,
                HocKy = diems.HocKy,
                DiemGiuaKy = diems.DiemGiuaKy,
                DiemCuoiKy = diems.DiemCuoiKy,
                DiemTongKet = diems.DiemTongKet,
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var diems = await _diemReponsitory.GetById(id);
            if (diems == null)
            {
                return NotFound($"{id} không tồn tại");
            }
            return Ok(new DiemDTO()
            {
                Id = diems.Id,
                HocKy = diems.HocKy,
                DiemGiuaKy = diems.DiemGiuaKy,
                DiemCuoiKy = diems.DiemCuoiKy,
                DiemTongKet = diems.DiemTongKet,
            });
        }
    }
}

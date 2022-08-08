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
    public class MonHocsController : ControllerBase
    {
        private readonly IMonHocReponsitory _monHocReponsitory;

        public MonHocsController(IMonHocReponsitory monHocReponsitory)
        {
            _monHocReponsitory = monHocReponsitory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] MonHocSearch monHocSearch)
        {
            var monhocs = await _monHocReponsitory.GetMonHocList(monHocSearch);
            var monhocDTOs = monhocs.Select(x => new MonHocDTO()
            {
                Id = x.Id,
                TenMonHoc = x.TenMonHoc,
                SoTinChi = x.SoTinChi
            });
            return Ok(monhocDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]MonHocCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var monhoc = await _monHocReponsitory.Create(new MonHoc()
            {
                Id = request.Id,
                TenMonHoc = request.TenMonHoc,
                SoTinChi = request.SoTinChi
            });
            return CreatedAtAction(nameof(GetById), new { id = monhoc.Id }, monhoc);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]MonHocUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var monhocFromDB = await _monHocReponsitory.GetById(id);
            if (monhocFromDB == null)
            {
                return NotFound($"{id} không tồn tại");
            }
            monhocFromDB.TenMonHoc = request.TenMonHoc;
            monhocFromDB.SoTinChi = request.SoTinChi;

            var monhocs = await _monHocReponsitory.Update(monhocFromDB);
            return Ok(new MonHocDTO()
            {
                Id = monhocs.Id,
                TenMonHoc = monhocs.TenMonHoc,
                SoTinChi = monhocs.SoTinChi
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var monhocs = await _monHocReponsitory.GetById(id);
            if (monhocs == null)
            {
                return NotFound($"{id} không tồn tại");
            }
            return Ok(new MonHocDTO()
            {
                Id = monhocs.Id,
                TenMonHoc = monhocs.TenMonHoc,
                SoTinChi = monhocs.SoTinChi
            });
        }
    }
}

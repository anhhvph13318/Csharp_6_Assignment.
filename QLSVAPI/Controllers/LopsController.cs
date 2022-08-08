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
    public class LopsController : ControllerBase
    {
        private readonly ILopReponsitory _lopReponsitory;

        public LopsController(ILopReponsitory lopReponsitory)
        {
            _lopReponsitory = lopReponsitory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] LopSearch lopSearch)
        {
            var lops = await _lopReponsitory.GetLopList(lopSearch);
            var lopDTOs = lops.Select(x => new LopDTO()
            {
                Id = x.Id,
                TenLop = x.TenLop,
                Nganh = x.Nganh,
            });
            return Ok(lopDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]LopCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lop = await _lopReponsitory.Create(new Lop()
            {
                Id = request.Id,
                TenLop = request.TenLop,
                Nganh = request.Nganh
            });
            return CreatedAtAction(nameof(GetById), new { id = lop.Id }, lop);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]LopUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lopFromDB = await _lopReponsitory.GetById(id);
            if (lopFromDB == null)
            {
                return NotFound($"{id} không tồn tại");
            }
            lopFromDB.TenLop = request.TenLop;
            lopFromDB.Nganh = request.Nganh;

            var lops = await _lopReponsitory.Update(lopFromDB);
            return Ok(new LopDTO()
            {
                Id = lops.Id,
                TenLop = lops.TenLop,
                Nganh = lops.Nganh
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var lops = await _lopReponsitory.GetById(id);
            if (lops == null)
            {
                return NotFound($"{id} không tồn tại");
            }
            return Ok(new LopDTO()
            {
                Id = lops.Id,
                TenLop = lops.TenLop,
                Nganh = lops.Nganh
            });
        }
    }
}

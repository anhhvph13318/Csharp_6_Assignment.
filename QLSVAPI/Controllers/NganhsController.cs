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
    public class NganhsController : ControllerBase
    {
        private readonly INganhReponsitory _nganhReponsitory;

        public NganhsController(INganhReponsitory nganhReponsitory)
        {
            _nganhReponsitory = nganhReponsitory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] NganhSearch nganhSearch)
        {
            var nganhs = await _nganhReponsitory.GetNganhList(nganhSearch);
            var nganhDTOs = nganhs.Select(x => new NganhDTO()
            {
                Id = x.Id,
                TenNganh = x.TenNganh,
            });
            return Ok(nganhDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]NganhCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nganh = await _nganhReponsitory.Create(new Nganh()
            {
                Id = request.Id,
                TenNganh = request.TenNganh
            });
            return CreatedAtAction(nameof(GetById), new { id = nganh.Id }, nganh);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]NganhUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nganhFromDB = await _nganhReponsitory.GetById(id);
            if (nganhFromDB == null)
            {
                return NotFound($"{id} không tồn tại");
            }
            nganhFromDB.TenNganh = request.TenNganh;

            var nganhs = await _nganhReponsitory.Update(nganhFromDB);
            return Ok(new NganhDTO()
            {
                Id = nganhs.Id,
                TenNganh = nganhs.TenNganh
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var nganhs = await _nganhReponsitory.GetById(id);
            if (nganhs == null)
            {
                return NotFound($"{id} không tồn tại");
            }
            return Ok(new NganhDTO()
            {
                Id = nganhs.Id,
                TenNganh = nganhs.TenNganh,
            });
        }
    }
}

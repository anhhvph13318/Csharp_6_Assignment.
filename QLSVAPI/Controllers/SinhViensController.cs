using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSV.Model;
using QLSV.Model.Data;
using QLSV.Model.Search;
using QLSVAPI.Entities;
using QLSVAPI.Reponsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLSVAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhViensController : ControllerBase
    {
        private readonly ISVReponsitory _svReponsitory;

        public SinhViensController(ISVReponsitory svReponsitory)
        {
            _svReponsitory = svReponsitory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SinhVienSearch sinhVienSearch)
        {
            var sinhviens = await _svReponsitory.GetSVList(sinhVienSearch);
            var sinhvienDTOs = sinhviens.Select(x => new SinhVienDTO()
            {
                Id = x.Id,
                TenSinhVien = x.TenSinhVien,
                Tuoi = x.Tuoi,
                DiaChi = x.DiaChi,
                Email = x.Email,
                SDT = x.SDT,
                GioiTinh = x.GioiTinh,
                Lop = x.Lop,
                UserName = x.User != null ? x.User.HoTen : "Chưa có",
            });
            return Ok(sinhvienDTOs);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _svReponsitory.Delete(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]SinhVienCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sinhvien = await _svReponsitory.Create(new SinhVien()
            {
                Id = request.Id,
                TenSinhVien = request.TenSinhVien,
                Tuoi = request.Tuoi,
                DiaChi = request.DiaChi,
                Email = request.Email,
                SDT = request.SDT,
                GioiTinh = request.GioiTinh,
                Lop = request.Lop,
            });
            return CreatedAtAction(nameof(GetById), new { id = sinhvien.Id}, sinhvien);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]SinhVienUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svFromDB = await _svReponsitory.GetById(id);
            if(svFromDB == null)
            {
                return NotFound($"{id} không tồn tại");
            }
            svFromDB.TenSinhVien = request.TenSinhVien;
            svFromDB.Tuoi = request.Tuoi;
            svFromDB.DiaChi = request.DiaChi;
            svFromDB.Email = request.Email;
            svFromDB.SDT = request.SDT;
            svFromDB.GioiTinh = request.GioiTinh;
            svFromDB.Lop = request.Lop;

            var sinhviens = await _svReponsitory.Update(svFromDB);
            return Ok(new SinhVienDTO() {
                Id = sinhviens.Id,
                TenSinhVien = sinhviens.TenSinhVien,
                Tuoi = sinhviens.Tuoi,
                DiaChi = sinhviens.DiaChi,
                Email = sinhviens.Email,
                SDT = sinhviens.SDT,
                GioiTinh = sinhviens.GioiTinh,
                Lop = sinhviens.Lop,
                UserId = sinhviens.UserId
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var sinhviens = await _svReponsitory.GetById(id);
            if(sinhviens == null)
            {
                return NotFound($"{id} không tồn tại");
            }
            return Ok(new SinhVienDTO()
            {
                Id = sinhviens.Id,
                TenSinhVien = sinhviens.TenSinhVien,
                Tuoi = sinhviens.Tuoi,
                DiaChi = sinhviens.DiaChi,
                Email = sinhviens.Email,
                SDT = sinhviens.SDT,
                GioiTinh = sinhviens.GioiTinh,
                Lop = sinhviens.Lop,
                UserId = sinhviens.UserId
            });
        }
    }
}

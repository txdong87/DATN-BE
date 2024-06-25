using Application.DTOs;
using Application.DTOs.CaseStudy;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCdhaCaseStudyController : ControllerBase
    {
        private readonly IMedicalCdhaCaseStudyService _service;

        public MedicalCdhaCaseStudyController(IMedicalCdhaCaseStudyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalCdhaCaseStudyDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalCdhaCaseStudyDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(MedicalCdhaCaseStudyDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, MedicalCdhaCaseStudyDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        [HttpPost("add-medical-cdha")]
        public async Task<ActionResult> AddMedicalCdhasToCaseStudy(int caseStudyId, List<GetMedicalCdhaDto> dtos)
        {
            await _service.AddMedicalCdhasToCaseStudyAsync(caseStudyId, dtos);
            return Ok();
        }

        [HttpPut("update-medical-cdha")]
        public async Task<ActionResult> UpdateMedicalCdhaCaseStudy(MedicalCdhaCaseStudyDto dto)
        {
            await _service.UpdateMedicalCdhaCaseStudyAsync(dto);
            return NoContent();
        }
    }
}

using Application.DTOs;
using Application.DTOs.CaseStudy;
using Application.DTOs.MedicalCdhaCaseStudyDTO;
using Application.Interfaces;
using Application.Exceptions;
using Application.Services;
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
        public async Task<ActionResult<IEnumerable<GetMedicalCdhaCaseStudyDto>>> GetAll()
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
        [HttpPost("{caseStudyId}")]
        public async Task<IActionResult> AddMedicalCdhaToCaseStudy(int caseStudyId, [FromBody] AddMedicalCdhaCaseStudyDto requestDto)
        {
            try
            {
                await _service.AddMedicalCdhasToCaseStudyAsync(caseStudyId, requestDto);

                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }
        [HttpPut("update-medical-cdha")]
        public async Task<ActionResult> UpdateMedicalCdhaCaseStudy(MedicalCdhaCaseStudyDto dto)
        {
            await _service.UpdateMedicalCdhaCaseStudyAsync(dto);
            return NoContent();
        }
    }
}

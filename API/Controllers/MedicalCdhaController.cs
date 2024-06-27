using Application.Services;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCdhasController : ControllerBase
    {
        private readonly IMedicalCdhaService _medicalCdhaService;

        public MedicalCdhasController(IMedicalCdhaService medicalCdhaService)
        {
            _medicalCdhaService = medicalCdhaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalCdha>>> GetAll()
        {
            var medicalCdhas = await _medicalCdhaService.GetAllMedicalCdhasAsync();
            return Ok(medicalCdhas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalCdha>> GetById(int id)
        {
            var medicalCdha = await _medicalCdhaService.GetMedicalCdhaByIdAsync(id);
            if (medicalCdha == null)
            {
                return NotFound();
            }
            return Ok(medicalCdha);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(MedicalCdha entity)
        {
            var entityId = await _medicalCdhaService.CreateMedicalCdhaAsync(entity);
            return Ok(entityId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MedicalCdha entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            await _medicalCdhaService.UpdateMedicalCdhaAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _medicalCdhaService.DeleteMedicalCdhaAsync(id);
            return NoContent();
        }
    }
}

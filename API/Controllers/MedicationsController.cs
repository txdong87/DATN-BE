using Application.DTOs;
using Application.DTOs.Users;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationsController : ControllerBase
    {
        private readonly IMedicationService _medicationService;

        public MedicationsController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medications = await _medicationService.GetAllMedications();
            return Ok(medications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medication = await _medicationService.GetMedicationById(id);
            if (medication == null) return NotFound();
            return Ok(medication);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MedicationDto medicationDto)
        {
            await _medicationService.AddMedication(medicationDto);
            return CreatedAtAction(nameof(GetById), new { id = medicationDto.Id }, medicationDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MedicationDto medicationDto)
        {
            if (id != medicationDto.Id) return BadRequest();
            await _medicationService.UpdateMedication(medicationDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _medicationService.DeleteMedication(id);
            return NoContent();
        }
    }

   
}

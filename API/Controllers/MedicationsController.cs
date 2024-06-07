using Application;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly IMedicationService _medicationService;

        public MedicationsController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medication>>> GetAllMedications()
        {
            var medications = await _medicationService.GetAllMedicationsAsync();
            return Ok(medications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medication>> GetMedicationById(int id)
        {
            var medication = await _medicationService.GetMedicationByIdAsync(id);
            if (medication == null)
            {
                return NotFound();
            }
            return Ok(medication);
        }

        [HttpPost]
        public async Task<ActionResult> AddMedication(MedicationDTO medicationDto)
        {
            var medication = new Medication
            {
                Name = medicationDto.Name,
                Unit = medicationDto.Unit,
                Route = medicationDto.Route,
                Usage = medicationDto.Usage,
                IsFunctionalFoods = medicationDto.IsFunctionalFoods
            };

            await _medicationService.AddMedicationAsync(medication);
            return CreatedAtAction(nameof(GetMedicationById), new { id = medication.Id }, medication);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMedication(int id, Medication medication)
        {
            if (id != medication.Id)
            {
                return BadRequest();
            }

            await _medicationService.UpdateMedicationAsync(medication);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMedication(int id)
        {
            await _medicationService.DeleteMedicationAsync(id);
            return NoContent();
        }
    }
}

using Application.DTOs;
using Application.DTOs.PrescriptionDTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prescriptions = await _prescriptionService.GetAllPrescriptions();
            return Ok(prescriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var prescription = await _prescriptionService.GetPrescriptionById(id);
            if (prescription == null) return NotFound();
            return Ok(prescription);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PrescriptionDto prescriptionDto)
        {
            await _prescriptionService.AddPrescription(prescriptionDto);
            return CreatedAtAction(nameof(GetById), new { id = prescriptionDto.Id }, prescriptionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PrescriptionDto prescriptionDto)
        {
            if (id != prescriptionDto.Id) return BadRequest();
            await _prescriptionService.UpdatePrescription(prescriptionDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _prescriptionService.DeletePrescription(id);
            return NoContent();
        }
    }
}

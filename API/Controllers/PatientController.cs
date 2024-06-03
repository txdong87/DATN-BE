using Application.DTOs;
using Domain.Entities;
using Domain.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientRepository.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientDTO patientDto)
        {
            if (patientDto == null)
            {
                return BadRequest();
            }

            var patient = new Patient
            {
                PatientName = patientDto.PatientName,
                Address = patientDto.Address,
                Sex = patientDto.Sex,
                Dob = patientDto.Dob,
                Phone = patientDto.Phone,
                Roomld = patientDto.RoomId,
                Doctorld=patientDto.DoctorId
            };

            await _patientRepository.AddPatientAsync(patient);

            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Patientld}, patient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientRepository.DeletePatientAsync(id);
            return NoContent();
        }
    }
}

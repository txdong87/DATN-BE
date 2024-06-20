using Application.DTOs.CaseStudy;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Application.Interfaces;
using Application.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseStudyController : ControllerBase
    {
        private readonly ICaseStudyService _caseStudyService;

        public CaseStudyController(ICaseStudyService caseStudyService)
        {
            _caseStudyService = caseStudyService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCaseStudyDto>> GetCaseStudyById(int id)
        {
            var caseStudy = await _caseStudyService.GetCaseStudyByIdAsync(id);
            if (caseStudy == null)
            {
                return NotFound();
            }

            return Ok(caseStudy);
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<GetCaseStudyDto>>> GetAllCaseStudies()
        {
            var caseStudies = await _caseStudyService.GetAllCaseStudiesAsync();
            return Ok(caseStudies);
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult> AddCaseStudy([FromBody] CreateCaseStudyDto createCaseStudyDto)
        {
            try
            {
                await _caseStudyService.AddCaseStudyAsync(createCaseStudyDto);
                return CreatedAtAction(nameof(GetCaseStudyById), new { id = createCaseStudyDto.patientId }, createCaseStudyDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<ActionResult> UpdateCaseStudy(int id, [FromBody] UpdateCaseStudyDto updateCaseStudyDto)
        {
            await _caseStudyService.UpdateCaseStudyAsync(id, updateCaseStudyDto);
            return NoContent();
        }

        [HttpPut("{caseStudyId}/report")]
        public async Task<IActionResult> UpdateReport(int caseStudyId, [FromBody] ReportDTO reportDto)
        {
            await _caseStudyService.UpdateReportAsync(caseStudyId, reportDto);
            return NoContent();
        }

        [HttpPut("{caseStudyId}/medicalCdha")]
        public async Task<IActionResult> UpdateMedicalCdha(int caseStudyId, [FromBody] MedicalCdhaDTO medicalCdhaDto)
        {
            await _caseStudyService.UpdateMedicalCdhaAsync(caseStudyId, medicalCdhaDto);
            return NoContent();
        }

        [HttpPut("{caseStudyId}/prescription")]
        public async Task<IActionResult> UpdatePrescription(int caseStudyId, [FromBody] PrescriptionDto prescriptionDto)
        {
            await _caseStudyService.UpdatePrescriptionAsync(caseStudyId, prescriptionDto);
            return NoContent();
        }
    }
}

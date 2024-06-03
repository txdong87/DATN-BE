using Application.DTOs.CaseStudy;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseStudyController : ControllerBase
    {
        private readonly CaseStudyService _caseStudyService;

        public CaseStudyController(CaseStudyService caseStudyService)
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
        public async Task<ActionResult<IEnumerable<GetCaseStudyDto>>> GetAllCaseStudies()
        {
            var caseStudies = await _caseStudyService.GetAllCaseStudiesAsync();
            return Ok(caseStudies);
        }

        [HttpPost]
        public async Task<ActionResult> AddCaseStudy([FromBody] CreateCaseStudyDto createCaseStudyDto)
        {
            try
            {
                await _caseStudyService.AddCaseStudyAsync(createCaseStudyDto);
                return CreatedAtAction(nameof(GetCaseStudyById), new { id = createCaseStudyDto.PatientId }, createCaseStudyDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCaseStudy(int id, [FromBody] UpdateCaseStudyDto updateCaseStudyDto)
        {
            await _caseStudyService.UpdateCaseStudyAsync(id, updateCaseStudyDto);
            return NoContent();
        }
    }
}

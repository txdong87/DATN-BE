using Application.DTOs;
using Application.DTOs.CaseStudy;
using Application.DTOs.MedicalCdhaCaseStudyDTO;
using Application.Interfaces;
using Application.Exceptions;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCdhaCaseStudyController : ControllerBase
    {
        private readonly IMedicalCdhaCaseStudyService _service;
        private readonly ICaseStudyService _caseStudyService;
        private readonly IMedicalCdhaService _medicalCdhaService;

        public MedicalCdhaCaseStudyController(IMedicalCdhaCaseStudyService service, ICaseStudyService caseStudyService,IMedicalCdhaService medicalCdhaService)
        {
            _service = service;
            _caseStudyService = caseStudyService;
            _medicalCdhaService = medicalCdhaService;
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

        //[HttpPost]
        //public async Task<ActionResult> Create(MedicalCdhaCaseStudyDto dto)
        //{
        //    await _service.AddAsync(dto);
        //    return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromForm] MedicalCdhaCaseStudyDto dto, IFormFile file)
        {
            try
            {
                var existingDto = await _service.GetByIdAsync(id);
                if (existingDto == null)
                {
                    return NotFound(); 
                }
                var caseStudy = await _caseStudyService.GetCaseStudyByIdAsync(dto.CaseStudyId ?? 0);
                var medicalCdha = await _medicalCdhaService.GetMedicalCdhaByIdAsync(dto.MedicalCdhaId ?? 0);
                if (file != null && file.Length > 0)
                {
                    var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                    if (!Directory.Exists(uploadsFolderPath))
                    {
                        Directory.CreateDirectory(uploadsFolderPath);
                    }

                    var fileName = $"{caseStudy.Patient.PatientName}-{dto.CaseStudyId}-{medicalCdha.CdhaName}-{Path.GetFileName(file.FileName)}";
                    var filePath = Path.Combine(uploadsFolderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    dto.ImageName = fileName;
                    dto.ImageLink = $"/uploads/{fileName}";
                }

                existingDto.Conclusion = dto.Conclusion;
                existingDto.Description = dto.Description;
                existingDto.ImageName = dto.ImageName;
                existingDto.ImageLink = dto.ImageLink;

                var updateDto = new GetMedicalCdhaCaseStudyDto
                {
                    Id = existingDto.Id,
                    KtvId = existingDto.KtvId,
                    CaseStudyId = existingDto.CaseStudyId,
                    MedicaCdhaId = existingDto.MedicaCdhaId,
                    ReportId = existingDto.ReportId,
                    Conclusion = existingDto.Conclusion,
                    Description = existingDto.Description,
                    ImageName = existingDto.ImageName,
                    ImageLink = existingDto.ImageLink
                };

                await _service.UpdateAsync(updateDto);

                return CreatedAtAction(nameof(GetById), new { id = updateDto.Id }, updateDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Create(MedicalCdhaCaseStudyDto dto)
        {
            try
            {
                //if (file != null && file.Length > 0)
                //{
                //    using (var memoryStream = new MemoryStream())
                //    {
                //        await file.CopyToAsync(memoryStream);
                //        dto.ImageName = file.FileName;
                //        dto.ImageLink = Convert.ToBase64String(memoryStream.ToArray());
                //    }
                //}

                await _service.AddAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
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

using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ReportController : Controller
    {
    [ApiController]
        [Route("api/[controller]")]
        public class ReportsController : ControllerBase
        {
            private readonly IReportService _reportService;

            public ReportsController(IReportService reportService)
            {
                _reportService = reportService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Report>>> GetAllReports()
            {
                var reports = await _reportService.GetAllReportsAsync();
                return Ok(reports);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Report>> GetReportById(int id)
            {
                var report = await _reportService.GetReportByIdAsync(id);
                if (report == null)
                {
                    return NotFound();
                }
                return Ok(report);
            }

            [HttpPost]
            public async Task<ActionResult<Report>> CreateReport(Report report)
            {
                var createdReport = await _reportService.CreateReportAsync(report);
                return CreatedAtAction(nameof(GetReportById), new { id = createdReport.ReportId }, createdReport);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateReport(int id, Report report)
            {
                if (id != report.ReportId)
                {
                    return BadRequest();
                }

                var updatedReport = await _reportService.UpdateReportAsync(report);
                if (updatedReport == null)
                {
                    return NotFound();
                }

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteReport(int id)
            {
                var result = await _reportService.DeleteReportAsync(id);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
        }
    }
}


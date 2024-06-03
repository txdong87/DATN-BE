using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NurseController : ControllerBase
    {
        private readonly INurseService _nurseService;

        public NurseController(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var nurse = await _nurseService.GetNurseByIdAsync(id);

            if (nurse == null)
            {
                return NotFound();
            }

            return Ok(nurse);
        }
    }
}

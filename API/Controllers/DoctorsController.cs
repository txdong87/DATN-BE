using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }
    }
}

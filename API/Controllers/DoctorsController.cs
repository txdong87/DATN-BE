using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IUserService _userService;

        public DoctorController(IDoctorService doctorService, IUserService userService)
        {
            _doctorService = doctorService;
            _userService = userService; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctorById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorCreateDto doctorDto)
        {
            try
            {
                // Kiểm tra xem người dùng có tồn tại và có RoleId = 1 không
                var role = await _userService.checkRole(doctorDto.UserId);
                if (role == null || role != 1)
                {
                    return BadRequest("Người dùng không hợp lệ hoặc không có quyền trở thành bác sĩ.");
                }
                var existingDoctor = await _doctorService.GetDoctorByIdAsync(doctorDto.UserId);
                if (existingDoctor != null)
                {
                    return BadRequest("Người dùng này đã là bác sĩ rồi");
                }
                // Tạo bác sĩ mới
                var newDoctor = new Doctor
                {
                    
                    UserId = doctorDto.UserId,
                    DoctorRole = doctorDto.DoctorRole
                };

                await _doctorService.AddDoctorAsync(newDoctor);

                return Ok(newDoctor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Đã xảy ra lỗi khi tạo bác sĩ: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return NoContent();
        }
    }
}

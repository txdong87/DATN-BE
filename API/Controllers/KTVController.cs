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
    public class KTVController : ControllerBase
    {
        private readonly IKTVService _KTVService;
        private readonly IUserService _userService;

        public KTVController(IKTVService KTVService, IUserService userService)
        {
            _KTVService = KTVService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KTV>>> GetAllKTVs()
        {
            var KTVs = await _KTVService.GetAllKTVsAsync();
            return Ok(KTVs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KTV>> GetKTVById(int id)
        {
            var KTV = await _KTVService.GetKTVByIdAsync(id);
            if (KTV == null)
            {
                return NotFound();
            }
            return Ok(KTV);
        }

        [HttpPost]
        public async Task<IActionResult> CreateKTV(GetKTVResponse KTVDto)
        {
            try
            {
                // Kiểm tra xem người dùng có tồn tại và có RoleId = 1 không
                var role = await _userService.checkRole(KTVDto.UserId);
                if (role == null || role != 2)
                {
                    return BadRequest("Người dùng không hợp lệ hoặc không có quyền trở thành điều dưỡng.");
                }
                var existingKTV = await _KTVService.GetKTVByIdAsync(KTVDto.UserId);
                if (existingKTV != null)
                {
                    return BadRequest("Người dùng này đã là điều dưỡng rồi");
                }
                // Tạo bác sĩ mới
                var newKTV = new KTV
                {

                    UserId = KTVDto.UserId,
                };

                await _KTVService.AddKTVAsync(newKTV);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Đã xảy ra lỗi khi tạo bác sĩ: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteKTV(int id)
        {
            await _KTVService.DeleteKTVAsync(id);
            return NoContent();
        }
    }
}

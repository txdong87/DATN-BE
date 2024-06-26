﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.DTOs.NurseDTO;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly INurseService _nurseService;
        private readonly IUserService _userService;

        public NurseController(INurseService nurseService, IUserService userService)
        {
            _nurseService = nurseService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nurse>>> GetAllnurses()
        {
            var nurses = await _nurseService.GetAllNursesAsync();
            return Ok(nurses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Nurse>> GetnurseById(int id)
        {
            var nurse = await _nurseService.GetNurseByIdAsync(id);
            if (nurse == null)
            {
                return NotFound();
            }
            return Ok(nurse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNurse(NurseDTO nurseDto)
        {
            try
            {
                // Kiểm tra xem người dùng có tồn tại và có RoleId = 1 không
                var role = await _userService.checkRole(nurseDto.UserId);
                if (role == null || role != 2)
                {
                    return BadRequest("Người dùng không hợp lệ hoặc không có quyền trở thành điều dưỡng.");
                }
                var existingnurse = await _nurseService.GetNurseByIdAsync(nurseDto.UserId);
                if (existingnurse != null)
                {
                    return BadRequest("Người dùng này đã là điều dưỡng rồi");
                }
                // Tạo bác sĩ mới
                var newnurse = new Nurse
                {

                    UserId = nurseDto.UserId,
                };

                await _nurseService.AddNurseAsync(newnurse);

                return Ok(newnurse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Đã xảy ra lỗi khi tạo điều dưỡng: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletenurse(int id)
        {
            await _nurseService.DeleteNurseAsync(id);
            return NoContent();
        }
    }
}

﻿using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.IRepository;
using Infrastructure.Persistence.Repositories;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthRepository _authRepository;

        public AuthController(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _authRepository.LoginAsync(request.Username, request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = _authRepository.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

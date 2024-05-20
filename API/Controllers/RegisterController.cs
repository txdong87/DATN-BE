using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.IRepository;
using Infrastructure.Persistence.Repositories;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public RegisterController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            // Kiểm tra xác thực và tạo tài khoản mới
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Kiểm tra xem tên người dùng đã tồn tại chưa
            var existingUser = await _authRepository.GetUserByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                return Conflict("Username already exists");
            }

            // Tạo tài khoản mới
            await _authRepository.CreateUserAsync(request.Username, request.Password,request.RoleId);

            return Ok("User created successfully");
        }
    }

    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int RoleId { get; set; }
    }
}

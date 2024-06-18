using Application.DTOs;
using Application.DTOs.Users;
using Application.DTOs.Users.CreateUser;
using Application.DTOs.Users.EditUser;
using Application.DTOs.Users.GetListUsers;
using Application.DTOs.Users.GetUser;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var userResponse = await _userService.GetAsync(new GetUserRequest { Id = id });
            if (userResponse == null)
            {
                return NotFound();
            }
            return Ok(userResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserRequest userRequest)
        {
            if (userRequest == null)
            {
                return BadRequest();
            }

            var response = await _userService.CreateUserAsync(userRequest);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] EditUserRequest userRequest)
        {
            if (userRequest == null || id != userRequest.UserId)
            {
                return BadRequest();
            }

            var response = await _userService.EditUserAsync(userRequest);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchUsers([FromBody] UserSearchDTO searchDto)
        {
            var users = await _userService.SearchUsersAsync(searchDto.Username, searchDto.Fullname, searchDto.Take, searchDto.Skip);
            return Ok(users);
        }
    }
}

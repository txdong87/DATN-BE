using Application.DTOs;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.IRepository;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly string _secretKey;
        private readonly IUserRepository _userRepository;

        public AuthService(IAuthRepository authRepository, IConfiguration configuration,IUserRepository userRepository)
        {
            _authRepository = authRepository;
            _secretKey = configuration["JwtSettings:Secret"];
            _userRepository = userRepository;
        }

        public async Task<string?> AuthenticateAsync(string username, string password)
        {
            var user = await _authRepository.LoginAsync(username, password);
            if (user == null || !VerifyPassword(password, user.Password))
            {
                return null; // Invalid login
            }

            return GenerateJwtToken(user); // Successful login
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Fullname),
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }

        public async Task RegisterUserAsync(string username, string password, int roleId,string fullname)
        {
            var existingUser = await _authRepository.GetUserByUsernameAsync(username);
            if (existingUser != null)
            {
                throw new Exception("User already exists.");
            }

            var hashedPassword = HashPassword(password);
            var user = new User
            {
                Fullname = fullname,
                Password = hashedPassword,
                RoleId = roleId,
                user = username
            };

            await _authRepository.CreateUserAsync(user);
        }
        public async Task<string> GetUserRoleAsync(string username)
        {
            return await _authRepository.GetUserRoleAsync(username);
        }
    }
}

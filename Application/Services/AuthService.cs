using Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Domain.Entities;

namespace Application.Services;
public class AuthService : IAuthService
{
    private readonly datnContext _context;
    private readonly string _jwtSecret;

    public AuthService(datnContext context, IConfiguration configuration)
    {
        _context = context;
        _jwtSecret = configuration["JwtSettings:Secret"]; // Lấy secret từ appsettings.json
    }

    public async Task<string> AuthenticateAsync(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Fullname == username && u.Password == password);

        if (user == null)
            return null;

        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Fullname),
                // Add more claims as needed
            }),
            Expires = DateTime.UtcNow.AddDays(1), // Token expires in 1 day
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
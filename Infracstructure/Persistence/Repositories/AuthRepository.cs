using Domain.Entities;
using Domain.Interfaces;
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BCrypt;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories;
public class AuthRepository : RepositoryBase<User>, IAuthRepository
{
    private readonly string _secretKey;

    public AuthRepository(datnContext dbContext, string secretKey) : base(dbContext)
    {
        _secretKey = secretKey;
    }

    public async Task<User> LoginAsync(string username, string password)
    {
        var user = await _dbSet.FirstOrDefaultAsync(u => u.Fullname == username);

        if (user == null || !VerifyPassword(password, user.Password))
        {
            return null; // Invalid login
        }

        return user; // Successful login
    }

    public string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, user.Fullname),
                    new Claim(ClaimTypes.NameIdentifier, user.Userld.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private bool VerifyPassword(string password, string storedHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, storedHash);
    }
}

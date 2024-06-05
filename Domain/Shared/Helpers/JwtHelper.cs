using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Shared.Constants;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Shared.Helpers
{
    public static class JwtHelper
    {
        private static readonly byte[] SecurityKey = Encoding.ASCII.GetBytes(JwtSettings.SecurityKey);

        public static string GenerateJwtToken(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Userld == null) throw new ArgumentNullException(nameof(user.Userld), "User ID cannot be null");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSettings.SecurityKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtSettings.IdTokenClaimName, user.Userld.ToString())
                }),

                Expires = DateTime.UtcNow.AddDays(JwtSettings.ExpiredTimeInDay),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),

                Issuer = JwtSettings.Issuer,
                Audience = JwtSettings.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static int? ValidateJwtToken(string? token)
        {
            if (token == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSettings.SecurityKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = JwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = JwtSettings.Audience,
                    ClockSkew = TimeSpan.Zero
                },
                    out var validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var userId = int.Parse(jwtToken.Claims
                                                .First(c => c.Type == JwtSettings.IdTokenClaimName)
                                                .Value);

                return userId;
            }
            catch
            {
                return null;
            }
        }
    }
}

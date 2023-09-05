using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Api.JWT
{
    public class JwtUtils
    {
        public static string GenerateToken(UserToken user)
        {
            ArgumentNullException.ThrowIfNull(user);
            var secretKey = SecretKey.GetWithEncoding();

            var subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", user.Id)
            });

            if (!string.IsNullOrEmpty(user.GroupId))
            {
                subject.AddClaim(new Claim("GroupId", user.GroupId));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

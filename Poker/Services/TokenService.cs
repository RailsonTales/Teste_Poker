using Poker.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Poker.Services
{
    public class TokenService
    {
        public string Generate(User user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Poker.Configuration.PrivateKey);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = credentials,
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(User user)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Name));

            return ci;
        }
    }
}

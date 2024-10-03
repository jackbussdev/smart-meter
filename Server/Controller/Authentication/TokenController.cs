using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Server.Controller.Authentication
{
    internal class TokenController : ITokenController
    {
        public string GenerateTokenForUsername(string username)
        {
            List<Claim> Claims = [
                new(ClaimTypes.Name, username),
                new(ClaimTypes.Role, "Meter")
            ];

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes("X")); // insert key here

            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken token = new(
                claims: Claims,
                expires: DateTime.UtcNow.AddDays(365),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
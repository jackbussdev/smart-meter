using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Server.ServiceManager.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controller.Authentication
{
    internal class TokenController : ITokenController
    {
        public string generateTokenForUsername(string username)
        {
            List<Claim> Claims = new List<Claim> {
                new(ClaimTypes.Name, username),
                new(ClaimTypes.Role, "Meter")
            };

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
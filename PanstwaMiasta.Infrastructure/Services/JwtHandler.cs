using Microsoft.IdentityModel.Tokens;
using PanstwaMiasta.Infrastructure.DTO;
using PanstwaMiasta.Infrastructure.Extensions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PanstwaMiasta.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        public JwtDto CreateToken(Guid playerId)
        {
            var timeNow = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, playerId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, playerId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, timeNow.ToTimeStamp().ToString(), ClaimValueTypes.Integer64)
            };

            var expires = timeNow.AddMinutes(5);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super_secret_key_123")), SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                claims: claims,
                notBefore: timeNow,
                expires: expires,
                signingCredentials: signingCredentials
           );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                Token = token,
                Expiry = expires.ToTimeStamp()
            };
        }
    }
}

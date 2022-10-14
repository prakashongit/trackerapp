using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CommonLibrary
{
    public class JWTService
    {
        private readonly string _secret;
        private readonly string _expDate;
        private readonly string _issuer;
        private readonly string _audience;

        public JWTService(IConfiguration config)
        {
            _secret = config.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = config.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
            _issuer = config.GetSection("JwtConfig").GetSection("Issuer").Value;
            _audience = config.GetSection("JwtConfig").GetSection("Audience").Value;
        }

        public string GenerateSecurityToken(string userName, string role, int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userName),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.Sid, userId.ToString())
                };
            var token = new JwtSecurityToken(_issuer, _audience, claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(token);

        }
    }
}

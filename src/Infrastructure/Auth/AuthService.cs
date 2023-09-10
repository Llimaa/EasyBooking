using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EasyBooking.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EasyBooking.Infrastructure;

public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token GenerateJwtToken(string email, List<UserRole> roles)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"] ?? "";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>();
            claims.Add(new Claim("userName", email));
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Value));
            }

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: credentials,
                claims: claims);

        var tokenHandler = new JwtSecurityTokenHandler
        {
            TokenLifetimeInMinutes = (int)TimeSpan.FromHours(3).TotalMinutes
        };

        var stringToken = tokenHandler.WriteToken(token);
        var expireAt = tokenHandler.TokenLifetimeInMinutes;

            return new Token(stringToken, expireAt);
        }

        public string ComputeSha256Hash(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

        StringBuilder builder = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2")); // x2 Faz com que seja convertido em representações hexadecimal.
        }

        return builder.ToString();
    }
}
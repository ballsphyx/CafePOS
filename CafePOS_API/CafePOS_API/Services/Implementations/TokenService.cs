using CafePOS_API.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CafePOS_API.Services.Implementations
{
    public class TokenService(IConfiguration configuration, UserManager<Employee> userManager)
    {
        public async Task<string> GenerateTokenAsync(Employee employee)
        {
            var roles = await userManager.GetRolesAsync(employee);
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, employee.Id),
                new(JwtRegisteredClaimNames.Email, employee.Email!),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims.Add((new Claim(ClaimTypes.Role, role)));
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JWT:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokens = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(configuration["Jwt:ExpiryMinutes"]!)),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(tokens);
        }
    }
}

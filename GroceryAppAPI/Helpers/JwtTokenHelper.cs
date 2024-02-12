using GroceryAppAPI.Enumerations;
using GroceryAppAPI.Helpers.Interfaces;
using GroceryAppAPI.Models.DbModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GroceryAppAPI.Helpers
{
    public class JwtTokenHelper : IJwtTokenHelper
    {
        private readonly IConfiguration _configuration;

        public JwtTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Authentication:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userRole = (Role)user.Role;

            // Define claims for the token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, userRole.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // Create and configure the JWT token
            var token = new JwtSecurityToken(_configuration["AppSettings:Authentication:Issuer"],
                _configuration["AppSettings:Authentication:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            // Write and return the token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

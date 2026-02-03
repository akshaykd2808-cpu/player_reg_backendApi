using Microsoft.IdentityModel.Tokens;
using playerregproject.DTOs.UserDTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace playerregproject.Services
{
    public class JwtService
    {

        private readonly IConfiguration _configuration;


        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;

            
        }


        public string GenerateToken(RegisterRequestDTO RegisterRequest)
        {
            var claims = new List<Claim>()
            {
              new Claim(ClaimTypes.NameIdentifier,RegisterRequest.Username),
              new Claim(ClaimTypes.NameIdentifier,RegisterRequest.Password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
                );
                          


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using playerregproject.Data;
using playerregproject.DTOs.UserDTOs;
using playerregproject.Models;
using playerregproject.Services;
using System.Runtime.InteropServices;

namespace playerregproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly PlayerRegDbContext _dbContext;
        private readonly JwtService _jwtService;

        public AuthController(PlayerRegDbContext dbContext,JwtService jwtService)
        {
            _dbContext = dbContext;
            _jwtService = jwtService;
            
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] RegisterRequestDTO RegisterRequest)
        {
            if (RegisterRequest == null)
            {
                return BadRequest(new { message = "User can not be null" });
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(RegisterRequest.Password);

            var UserExist = await _dbContext.Users.FirstOrDefaultAsync(user =>
            user.Username == RegisterRequest.Username);

            if (UserExist == null)
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(RegisterRequest.Password, UserExist.Password);

            if (!isPasswordValid)
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var token = _jwtService.GenerateToken(RegisterRequest);


            //set httponly cookie


            Response.Cookies.Append("jwt_token", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddMinutes(60)
            });


            return Ok(new { authenticated = true });


        }

        [Authorize]
        [HttpGet("AuthUser")]

        public IActionResult AuthUser()
        {
            return Ok(new
            { authenticated = true });
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {

            Response.Cookies.Delete("jwt_token", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            return Ok(new { message = "Logged out successfully" });
           
        }

        [HttpPost("Register")]
        public async  Task<ActionResult> Register([FromBody] RegisterRequestDTO RegisterRquest)
        {
            if(RegisterRquest == null)
            {
                return BadRequest(new { message = "User can not be null" });
            }

            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(user =>
            user.Username == RegisterRquest.Username);

            if(existingUser != null)
            {
                return BadRequest(new { message = "User already exist" });
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(RegisterRquest.Password);

            var user = new User
            {

                Username = RegisterRquest.Username,
                Password = hashedPassword
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            //jwt token 

            var token = _jwtService.GenerateToken(RegisterRquest);



            return Ok(new {token});
        }

    }
}

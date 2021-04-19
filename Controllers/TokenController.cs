using meistrelis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using meistrelis.Dtos;
using user.PostgreSQL;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace meistrelis.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly MeistrelisContext _context;
 
        public TokenController(IConfiguration config, MeistrelisContext context)
        {
            _configuration = config;
            _context = context;
        }
 
        [HttpPost]
        public async Task<IActionResult> Post(UserAuthenticateDto _userData)
        {

            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.Email);
 
                if (user != null && PasswordIsCorrect(_userData.Password, user))
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Fullname", user.Fullname),
                    new Claim("Email", user.Email)
                   };
 
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY") ?? _configuration["Jwt:Key"]));
 
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
 
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
 
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
 
        private async Task<User> GetUser(string email)
        {
            
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        private bool PasswordIsCorrect(string password, User user)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.Password);   
        }
    }
}
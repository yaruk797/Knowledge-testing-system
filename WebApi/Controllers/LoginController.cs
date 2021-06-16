using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService _userService;

        public LoginController(IUserService userService,  IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            UserModel user = await _userService.GetByUsernameAndPasswordAsync(model.Email, model.Password);

            if (user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                return Ok(new { token = tokenStr, role = user.Role });
            }
            return Unauthorized();
        }
        private string GenerateJSONWebToken(UserModel model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials);

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            UserModel user = new UserModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Email,
                Password = model.Password,
                Role = "user"
            };
            
            await _userService.AddAsync(user);
            return Ok(model);
            
        }

    }
}

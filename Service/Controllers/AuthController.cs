using BussinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserLogic _userLogic;

        public AuthController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]    
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var userToAuthenticate =
                _userLogic.GetByFilter(u => u.Username == user.Username && u.Password == user.Password);

            if (userToAuthenticate == null)
            {
                return Json(new { status = false, message = "Invalid credentials!" });
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userToAuthenticate.Password),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("497239789f79dydfhjashu23hh4g32u4"));

            var token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience : "http://oec.com",
                expires: DateTime.UtcNow.AddHours(3),
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            
            return Json(new { status = true, message = "Login Successfull!" });
        }
    }
}
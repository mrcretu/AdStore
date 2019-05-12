using BussinessLogic.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Models;

namespace Service.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserLogic _userLogic;

        public AccountController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authorize(User userDto)
        {
//            var user = _userLogic.Authenticate(userDto.Username, userDto.Password);

            /*if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect." });
            }

            if (user.Role == Entities.Enums.Roles.Regular)
            {
                return Json(new { status = true, message = "Logged as regular." });
            }

            if (user.Role == Entities.Enums.Roles.Administrator)
            {
                return Json(new { status = true, message = "Logged as admin." });
            }*/

            return Json(new { status = false, message = "Login failed." });
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRBS.Project.API.Models;
using MRBS.Project.BusinessAccessLayer.Services;
using MRBS.Project.DataAccessLayer.ViewModel;

namespace MRBS.Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            User? user = _userService.ValidateUser(login);
            if (user == null)
            {
                return BadRequest("Invalid username or password.");
            }
            else
            {
                var token = _userService.GenerateToken(user);
                return Ok(new { token });
            }
        }
    }
}

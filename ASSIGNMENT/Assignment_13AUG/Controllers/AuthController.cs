using Assignment_13AUG.Model;
using Assignment_13AUG.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_13AUG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var token = _service.Login(
                user.UserName,
                user.Password);

            if (token == null)
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(new
            {
                token = token
            });
        }
    }
}
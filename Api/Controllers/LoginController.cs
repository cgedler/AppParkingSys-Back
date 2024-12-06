using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private IUserService _userService;

        public LoginController(ILogger<LoginController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest loginRequest)
        {
            _logger.LogInformation("Login post");

            var user = _userService.GetUserByEmail(loginRequest.Email);
            if (user == null)
            {
                return NotFound();
            }
            //your logic for login process
            // find user
            //If login usrename and password are correct then proceed to generate token
            //var token = GenerateToken(User);
            return Ok(user);
        }
    }
}

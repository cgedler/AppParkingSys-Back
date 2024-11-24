using AppParkingSys_Back.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Logging;
using AppParkingSys_Back.Core.Entities;

namespace AppParkingSys_Back.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private IUserService _userService;
        private readonly ILogger<LoginController> _logger;
        public LoginController(IConfiguration config, IUserService userService, ILogger<LoginController> logger)
        {
            _config = config;
            _userService = userService;
            _logger = logger;
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

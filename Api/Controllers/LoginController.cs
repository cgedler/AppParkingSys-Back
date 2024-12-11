using Api.Models;
using Api.Settings;
using Api.Settings.Security;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    /// <summary>
    /// Class <c>LoginController</c>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;


        public LoginController(ILogger<LoginController> logger, IUserService userService, IMapper mapper, IJwtService jwtService)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Method <c>Login</c> This method receives the user data to perform the validation, returns an access token.
        /// <example>
        /// <code>
        /// {
        ///     "email": "example@example.com",
        ///     "password": "123456"
        /// }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="loginRequest">Data from the request</param>
        /// <returns>Access token</returns>

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            _logger.LogInformation("Login post");
            IActionResult response = Unauthorized();
            var user = await _userService.GetUserByEmail(loginRequest.Email);
            if (user == null)
            {
                _logger.LogInformation("LoginController - post: User not found!");
                response = NotFound("User not found!");
                return response;
            }
            var mappedUser = _mapper.Map<User, UserModel>(user);
            bool validate = _jwtService.validatePassword(loginRequest.Password, mappedUser.PasswordHash);
            if (validate)
            {
                var tokenString = _jwtService.GenerateToken(user);
                _logger.LogInformation("LoginController - post: Token " + tokenString);
                response = Ok(new { token = tokenString });

            }
            else
            {
                response = BadRequest("Invalid Password");
            }
            return response;
        }
    }
}

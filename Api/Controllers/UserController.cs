using Api.Models;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    ///  Class <c>UserController</c> handles HTTP requests and interacts with the service.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            var user = await _userService.GetAll();

            var mappedUser = _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(user);

            return Ok(mappedUser);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            var user = await _userService.GetUserById(id);
            var mappedUser = _mapper.Map<User, UserModel>(user);
            return Ok(mappedUser);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<UserModel>> Post([FromBody] UserSaveModel user)
        {
            try
            {
                _logger.LogInformation("Inside post");
                var createdUser = await _userService.RegisterUser(_mapper.Map<UserSaveModel, User>(user));
                return Ok(_mapper.Map<User, UserModel>(createdUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UserController>/5
        // public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Put(int id, [FromBody] UserModel user)
        {
            _logger.LogInformation("Inside put");
            if (id != user.Id) 
            { 
                return BadRequest(); 
            }
            try
            {
                var updatedUser = await _userService.UpdateUser(id, _mapper.Map<UserModel, User>(user));
                return Ok(_mapper.Map<User, UserModel>(updatedUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Inside delete");
                var user = await _userService.DeleteUser(id);
                return Ok("Eliminated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

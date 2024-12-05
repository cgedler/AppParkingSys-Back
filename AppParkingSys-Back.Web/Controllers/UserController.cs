using AppParkingSys_Back.Core.Entities;
using AppParkingSys_Back.Core.Interfaces.Services;
using AppParkingSys_Back.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AppParkingSys_Back.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            var user =
                        await _userService.GetAll();

            var mappedUser =
                        _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(user);

            return Ok(mappedUser);
        }
    }
}

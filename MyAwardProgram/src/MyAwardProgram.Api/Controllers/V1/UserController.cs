using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAwardProgram.Api.Contracts.V1;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Responses;
using MyAwardProgram.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace MyAwardProgram.Api.Controllers.V1
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(ApiRoutes.User.Login)]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Authenticate([FromBody] LoginRequest loginRequest)
        {
            var response = _userService.LoginUser(loginRequest);

            if (response == null)
                return Unauthorized(response);

            return Ok(response);
        }

        [HttpPost(ApiRoutes.User.Register)]
        [AllowAnonymous]
        public async Task<ActionResult<NewUserResponse>> Register([FromBody] NewUserRequest newUserRequest)
        {
            var response = _userService.RegisterUser(newUserRequest);

            if (response == null)
                return BadRequest(response);

            return Created(ApiRoutes.User.BaseRoute + "/" + response.Id, response);
        }
    }
}

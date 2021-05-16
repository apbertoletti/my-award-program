using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAwardProgram.Domain.Entities.Users.DTOs.Requests;
using MyAwardProgram.Domain.Entities.Users.DTOs.Responses;
using MyAwardProgram.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace MyAwardProgram.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/Authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> Authenticate([FromBody]LoginRequest loginRequest)
        {
            var response = _userService.LoginUser(loginRequest);

            if (response == null)
                return Unauthorized();

            return Ok(response);
        }
    }
}

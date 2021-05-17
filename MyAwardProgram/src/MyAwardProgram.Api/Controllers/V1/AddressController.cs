using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAwardProgram.Api.Contracts.V1;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Responses;
using MyAwardProgram.Domain.Aggregates.Users.Enums;
using MyAwardProgram.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace MyAwardProgram.Api.Controllers.V1
{
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost(ApiRoutes.Address.Register)]
        [Authorize(Roles = "Consumer,Admin")]
        public async Task<ActionResult<NewAddressResponse>> Register([FromBody] NewAddressRequest newAddressRequest)
        {
            var response = _addressService.RegisterAddress(newAddressRequest);

            if (response == null)
                return BadRequest(response);

            return Created(ApiRoutes.Address.BaseRoute + "/" + response.Id, response);
        }
    }
}

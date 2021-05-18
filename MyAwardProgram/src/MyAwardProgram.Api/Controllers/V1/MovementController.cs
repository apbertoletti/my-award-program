using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAwardProgram.Api.Contracts.V1;
using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Responses;
using MyAwardProgram.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace MyAwardProgram.Api.Controllers.V1
{
    [ApiController]
    public class MovementController : ControllerBase
    {
        private IMovementService _movementService;

        public MovementController(IMovementService movementService)
        {
            _movementService = movementService;
        }

        [HttpPost(ApiRoutes.Movement.GetExtract)]
        [Authorize(Roles = "Consumer,Admin")]
        public async Task<ActionResult<ExtractResponse>> GetExtract([FromBody] ExtractRequest extractRequest)
        {
            var response = _movementService.GetExtract(extractRequest);
            
            return Ok(response);
        }
    }
}

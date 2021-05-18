using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAwardProgram.Api.Contracts.V1;
using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Responses;
using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using MyAwardProgram.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [HttpGet(ApiRoutes.Movement.GetExtract)]
        [Authorize(Roles = "Consumer,Admin")]
        public async Task<ActionResult<List<ExtractResponse>>> GetExtract([Required] int userId, [Required] DateTime startDate, [Required] DateTime endDate, MovementTypeEnum? movementType)
        {
            var response = _movementService.GetExtract(userId, startDate, endDate, movementType);
            
            return Ok(response);
        }
    }
}

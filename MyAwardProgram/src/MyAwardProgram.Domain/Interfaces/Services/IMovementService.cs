using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Responses;
using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using System;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Interfaces.Services
{
    public interface IMovementService
    {
        List<ExtractResponse> GetExtract(int userId, DateTime startDate, DateTime endDate, MovementTypeEnum? movementType);
    }
}

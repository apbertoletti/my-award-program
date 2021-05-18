using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Responses;
using System;

namespace MyAwardProgram.Domain.Interfaces.Services
{
    public interface IMovementService
    {
        ExtractResponse GetExtract(ExtractRequest extractRequest);
    }
}

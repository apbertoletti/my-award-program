using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Responses;
using MyAwardProgram.Domain.Interfaces.Repositories;
using MyAwardProgram.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace MyAwardProgram.Domain.Aggregates.Movements.Services
{
    public class MovementService : IMovementService
    {
        private IMovementRepository _movementRepository;

        public MovementService(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public ExtractResponse GetExtract(ExtractRequest extractRequest)
        {
            var movements = _movementRepository.Where(m => 
                m.UserId == extractRequest.UserId && 
                m.Occurrence >= extractRequest.StartDate && 
                m.Occurrence <= extractRequest.EndDate &&
                m.Type == extractRequest.Type).ToList();

            return new ExtractResponse
            {
                ExtractUser = movements
            };
        }
    }
}

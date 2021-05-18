using MyAwardProgram.Domain.Aggregates.Movements.DTOs.Responses;
using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using MyAwardProgram.Domain.Interfaces.Repositories;
using MyAwardProgram.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Aggregates.Movements.Services
{
    public class MovementService : IMovementService
    {
        private IMovementRepository _movementRepository;

        public MovementService(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public List<ExtractResponse> GetExtract(int userId, DateTime startDate, DateTime endDate, MovementTypeEnum? movementType)
        {
            var movements = _movementRepository.GetExtract(
                userId,
                startDate,
                endDate,
                movementType);

            var response = new List<ExtractResponse>();
            movements.ForEach(m =>
            {
                response.Add(new ExtractResponse
                {
                    Occurrence = m.Occurrence,
                    Type = m.Type,
                    Dots = m.Dots,
                    DueDate = m.DueDate,
                    Product = m.Product?.Name,
                    Partner = m.Product?.Partner.Name
                });
            });

            return response;
        }
    }
}

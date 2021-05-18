using MyAwardProgram.Domain.Aggregates.Movements.Entities;
using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using System;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Interfaces.Repositories
{
    public interface IMovementRepository : IRepository<Movement>
    {
        List<Movement> GetExtract(int userId, DateTime startDate, DateTime endDate, MovementTypeEnum? movementTypeEnum);
        long GetBalance(int id);
    }
}

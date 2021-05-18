using Microsoft.EntityFrameworkCore;
using MyAwardProgram.Data.Contexts;
using MyAwardProgram.Data.Repositories.Base;
using MyAwardProgram.Domain.Aggregates.Movements.Entities;
using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using MyAwardProgram.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAwardProgram.Data.Repositories
{
    public class MovementRepository : Repository<Movement>, IMovementRepository
    {
        public MovementRepository(AppContextDB context) : base(context)
        {
        }

        public List<Movement> GetExtract(int userId, DateTime startDate, DateTime endDate, MovementTypeEnum? movementType)
        {
            var query = DbSet
                            .Include(m => m.Product)
                                .ThenInclude(p => p.Partner)
                            .Where(
                                m => m.UserId == userId &&
                                m.Occurrence >= startDate &&
                                m.Occurrence <= endDate &&
                                (movementType == null ? true : m.Type == movementType))
                            .OrderBy(m => m.Occurrence);
            
            return query.ToList();
        }
    }
}

using MyAwardProgram.Data.Contexts;
using MyAwardProgram.Data.Repositories.Base;
using MyAwardProgram.Domain.Aggregates.Movements.Entities;
using MyAwardProgram.Domain.Interfaces.Repositories;

namespace MyAwardProgram.Data.Repositories
{
    public class MovementRepository : Repository<Movement>, IMovementRepository
    {
        public MovementRepository(AppContextDB context) : base(context)
        {
        }
    }
}

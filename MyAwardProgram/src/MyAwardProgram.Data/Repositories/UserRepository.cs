using MyAwardProgram.Data.Contexts;
using MyAwardProgram.Data.Repositories.Base;
using MyAwardProgram.Domain.Aggregates.Users;
using MyAwardProgram.Domain.Interfaces.Repositories;

namespace MyAwardProgram.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppContextDB context) : base(context)
        {
        }
    }
}

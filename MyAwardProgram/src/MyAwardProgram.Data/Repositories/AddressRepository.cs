using MyAwardProgram.Data.Contexts;
using MyAwardProgram.Data.Repositories.Base;
using MyAwardProgram.Domain.Aggregates.Users.Entities;
using MyAwardProgram.Domain.Interfaces.Repositories;

namespace MyAwardProgram.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(AppContextDB context) : base(context)
        {
        }
    }
}

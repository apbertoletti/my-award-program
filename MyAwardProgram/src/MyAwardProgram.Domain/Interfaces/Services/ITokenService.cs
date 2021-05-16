using MyAwardProgram.Domain.Aggregates.Users.Entities;

namespace MyAwardProgram.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}

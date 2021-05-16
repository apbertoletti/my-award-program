using MyAwardProgram.Domain.Aggregates.Users;

namespace MyAwardProgram.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}

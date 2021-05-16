using MyAwardProgram.Domain.Entities.Users;

namespace MyAwardProgram.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}

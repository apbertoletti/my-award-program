using MyAwardProgram.Domain.Entities.Users.DTOs.Requests;
using MyAwardProgram.Domain.Entities.Users.DTOs.Responses;

namespace MyAwardProgram.Domain.Interfaces.Services
{
    public interface IUserService
    {
        LoginResponse LoginUser(LoginRequest loginRequest);
    }
}

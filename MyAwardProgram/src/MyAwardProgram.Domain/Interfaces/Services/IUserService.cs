using MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Responses;

namespace MyAwardProgram.Domain.Interfaces.Services
{
    public interface IUserService
    {
        LoginResponse LoginUser(LoginRequest loginRequest);
        NewUserResponse RegisterUser(NewUserRequest newUserRequest);
    }
}

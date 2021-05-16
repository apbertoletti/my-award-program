using MyAwardProgram.Domain.Entities.Users.DTOs.Requests;
using MyAwardProgram.Domain.Entities.Users.DTOs.Responses;
using MyAwardProgram.Domain.Interfaces.Repositories;
using MyAwardProgram.Domain.Interfaces.Services;

namespace MyAwardProgram.Domain.Entities.Users.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private ITokenService _tokenService;

        public UserService(
            IUserRepository userRepository,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public LoginResponse LoginUser(LoginRequest loginRequest)
        {
            var user = _userRepository.Find(c =>
                c.Email == loginRequest.Email &&
                c.Password == loginRequest.Password);

            if (user == null)
                return null;

            var token = _tokenService.GenerateToken(user);

            return new LoginResponse
            {
                UserEmail = user.Email,
                UserRole = user.Role,
                Token = token
            };
        }
    }
}

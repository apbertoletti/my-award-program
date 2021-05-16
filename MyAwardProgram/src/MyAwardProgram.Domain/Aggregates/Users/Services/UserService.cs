using MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Responses;
using MyAwardProgram.Domain.Interfaces.Repositories;
using MyAwardProgram.Domain.Interfaces.Services;
using MyAwardProgram.Shared.Interfaces;

namespace MyAwardProgram.Domain.Aggregates.Users.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private ITokenService _tokenService;
        private ICryptoHelper _crypoHelper;

        public UserService(
            IUserRepository userRepository,
            ITokenService tokenService,
            ICryptoHelper crypoHelper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _crypoHelper = crypoHelper;
        }

        public LoginResponse LoginUser(LoginRequest loginRequest)
        {
            var user = _userRepository.Find(c =>
                c.Email == loginRequest.Email &&
                c.Password == _crypoHelper.GenerateHash(loginRequest.Password));

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

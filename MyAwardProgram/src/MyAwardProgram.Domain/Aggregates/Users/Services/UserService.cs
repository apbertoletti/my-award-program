using MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests;
using MyAwardProgram.Domain.Aggregates.Users.DTOs.Responses;
using MyAwardProgram.Domain.Aggregates.Users.Entities;
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
        private IMovementRepository _movementRepository;

        public UserService(
            IUserRepository userRepository,
            ITokenService tokenService,
            ICryptoHelper crypoHelper,
            IMovementRepository movementeRepository)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _crypoHelper = crypoHelper;
            _movementRepository = movementeRepository;
        }

        public LoginResponse LoginUser(LoginRequest loginRequest)
        {
            var user = _userRepository.Find(c =>
                c.Email == loginRequest.Email &&
                c.Password == _crypoHelper.GenerateHash(loginRequest.Password));

            if (user == null)
                return null;

            var token = _tokenService.GenerateToken(user);
            var balance = _movementRepository.GetBalance(user.Id);

            return new LoginResponse
            {
                UserId = user.Id,
                UserEmail = user.Email,
                DotsBalance = balance,
                UserRole = user.Role,
                Token = token
            };
        }

        public NewUserResponse RegisterUser(NewUserRequest newUserRequest)
        {
            var newUser = new User
            {
                CPF = newUserRequest.CPF,
                Name = newUserRequest.Name,
                Email = newUserRequest.Email,
                Password = _crypoHelper.GenerateHash(newUserRequest.Password),
                Phone = newUserRequest.Phone,
                Role = newUserRequest.Role
            };

            var addedUser = _userRepository.Add(newUser);
            _userRepository.SaveChanges();

            return new NewUserResponse
            {
                Id = addedUser.Id,
                CPF = addedUser.CPF.ToString(),
                Name = addedUser.Name,
                Email = addedUser.Email,
                Phone = addedUser.Phone,
                Role = addedUser.Role
            };
        }
    }
}

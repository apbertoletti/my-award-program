using MyAwardProgram.Domain.Entities.Users.Enums;

namespace MyAwardProgram.Domain.Entities.Users.DTOs.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

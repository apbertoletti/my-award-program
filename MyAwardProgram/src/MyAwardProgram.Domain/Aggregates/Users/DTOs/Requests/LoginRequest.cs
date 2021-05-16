using MyAwardProgram.Domain.Aggregates.Users.Enums;

namespace MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

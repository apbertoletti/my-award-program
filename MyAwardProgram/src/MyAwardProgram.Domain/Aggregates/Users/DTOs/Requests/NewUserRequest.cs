using MyAwardProgram.Domain.Aggregates.Users.Enums;

namespace MyAwardProgram.Domain.Aggregates.Users.DTOs.Requests
{
    public class NewUserRequest
    {
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}

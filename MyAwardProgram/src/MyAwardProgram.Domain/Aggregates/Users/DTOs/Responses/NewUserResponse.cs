using MyAwardProgram.Domain.Aggregates.Users.Enums;
using MyAwardProgram.Shared.Types;

namespace MyAwardProgram.Domain.Aggregates.Users.DTOs.Responses
{
    public class NewUserResponse
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}

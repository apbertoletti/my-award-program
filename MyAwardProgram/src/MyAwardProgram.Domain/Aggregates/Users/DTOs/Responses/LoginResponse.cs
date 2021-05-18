using MyAwardProgram.Domain.Aggregates.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAwardProgram.Domain.Aggregates.Users.DTOs.Responses
{
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public long DotsBalance { get; set; }
        public UserRoleEnum UserRole { get; set; }
        public string Token { get; set; }
    }
}

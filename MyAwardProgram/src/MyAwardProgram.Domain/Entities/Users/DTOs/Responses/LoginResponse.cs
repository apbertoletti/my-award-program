﻿using MyAwardProgram.Domain.Entities.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAwardProgram.Domain.Entities.Users.DTOs.Responses
{
    public class LoginResponse
    {
        public string UserEmail { get; set; }
        public UserRoleEnum UserRole { get; set; }
        public string Token { get; set; }
    }
}

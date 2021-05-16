using MyAwardProgram.Domain.Aggregates.Movements;
using MyAwardProgram.Domain.Aggregates.Movements.Entities;
using MyAwardProgram.Domain.Aggregates.Orders;
using MyAwardProgram.Domain.Aggregates.Orders.Entities;
using MyAwardProgram.Domain.Aggregates.Users.Enums;
using MyAwardProgram.Shared.Entities;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Aggregates.Users.Entities
{
    public class User : Entity<User>
    {
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public UserRoleEnum Role { get; set; }

        public ICollection<Address> Adresses { get; set; }
        public ICollection<Movement> Movements { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

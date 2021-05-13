using MyAwardProgram.Domain.Entities.Movements;
using MyAwardProgram.Domain.Entities.Orders;
using MyAwardProgram.Shared.Entities;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Entities.Users
{
    public class User : Entity<User>
    {
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public ICollection<UserAddress> Addresses { get; set; }
        public ICollection<Movement> Movements { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

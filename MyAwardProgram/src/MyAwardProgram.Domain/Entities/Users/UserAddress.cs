using MyAwardProgram.Domain.Entities.Orders;
using MyAwardProgram.Domain.Enums;
using MyAwardProgram.Shared.Entities;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Entities.Users
{
    public class UserAddress : Entity<UserAddress>
    {
        public string Name { get; set; }
        public AddressTypeEnum Type { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public User User { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}

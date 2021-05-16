﻿using MyAwardProgram.Domain.Entities.Orders;
using MyAwardProgram.Domain.Entities.Users.Enums;
using MyAwardProgram.Shared.Entities;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Entities.Users
{
    public class Address : Entity<Address>
    {
        public string Name { get; set; }
        public AddressTypeEnum Type { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public User User { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}

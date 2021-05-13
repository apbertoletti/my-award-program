using MyAwardProgram.Domain.Entities.Movements;
using MyAwardProgram.Domain.Entities.Partners;
using MyAwardProgram.Domain.Entities.Users;
using MyAwardProgram.Shared.Entities;
using System;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Entities.Orders
{
    public class Order : Entity<Order>
    {
        public DateTime Occurrence { get; set; }
        
        public User User { get; set; }
        public Address Address { get; set; }

        public ICollection<Movement> Movements { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

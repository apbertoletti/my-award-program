using MyAwardProgram.Domain.Aggregates.Movements;
using MyAwardProgram.Domain.Aggregates.Partners;
using MyAwardProgram.Domain.Aggregates.Users;
using MyAwardProgram.Shared.Entities;
using System;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Aggregates.Orders
{
    public class Order : Entity<Order>
    {
        public DateTime Occurrence { get; set; }
        
        public User User { get; set; }
        public Address Address { get; set; }

        public ICollection<Movement> Movements { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}

using MyAwardProgram.Domain.Aggregates.Movements.Entities;
using MyAwardProgram.Domain.Aggregates.Partners.Entities;
using MyAwardProgram.Domain.Aggregates.Users.Entities;
using MyAwardProgram.Shared.Entities;
using System;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Aggregates.Orders.Entities
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

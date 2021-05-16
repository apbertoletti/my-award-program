using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using MyAwardProgram.Domain.Aggregates.Orders;
using MyAwardProgram.Domain.Aggregates.Partners;
using MyAwardProgram.Domain.Aggregates.Users;
using MyAwardProgram.Shared.Entities;
using System;

namespace MyAwardProgram.Domain.Aggregates.Movements
{
    public class Movement : Entity<Movement>
    {
        public DateTime Occurrence { get; set; }
        public MovementTypeEnum Type { get; set; }
        public int Dots { get; set; }
        public DateTime DueDate { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}

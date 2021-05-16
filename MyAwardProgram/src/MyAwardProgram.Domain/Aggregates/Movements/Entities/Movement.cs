using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using MyAwardProgram.Domain.Aggregates.Orders.Entities;
using MyAwardProgram.Domain.Aggregates.Partners.Entities;
using MyAwardProgram.Domain.Aggregates.Users.Entities;
using MyAwardProgram.Shared.Entities;
using System;

namespace MyAwardProgram.Domain.Aggregates.Movements.Entities
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

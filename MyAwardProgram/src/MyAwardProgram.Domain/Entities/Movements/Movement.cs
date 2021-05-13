using MyAwardProgram.Domain.Entities.Orders;
using MyAwardProgram.Domain.Entities.Partners;
using MyAwardProgram.Domain.Entities.Users;
using MyAwardProgram.Domain.Enums;
using MyAwardProgram.Shared.Entities;
using System;

namespace MyAwardProgram.Domain.Entities.Movements
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

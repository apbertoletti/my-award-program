using MyAwardProgram.Domain.Aggregates.Movements;
using MyAwardProgram.Domain.Aggregates.Movements.Entities;
using MyAwardProgram.Domain.Aggregates.Orders;
using MyAwardProgram.Domain.Aggregates.Orders.Entities;
using MyAwardProgram.Domain.Aggregates.Partners.Enums;
using MyAwardProgram.Shared.Entities;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Aggregates.Partners.Entities
{
    public class Product : Entity<Product>
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public ProductDotTypeEnum DotType { get; set; }
        public int DotPrice { get; set; }

        public Partner Partner { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

        public ICollection<Movement> Movements { get; set; }
    }
}

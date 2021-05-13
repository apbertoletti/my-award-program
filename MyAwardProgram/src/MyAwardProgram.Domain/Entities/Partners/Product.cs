using MyAwardProgram.Domain.Entities.Movements;
using MyAwardProgram.Domain.Entities.Orders;
using MyAwardProgram.Domain.Enums;
using MyAwardProgram.Shared.Entities;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Entities.Partners
{
    public class Product : Entity<Product>
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public ProductDotTypeEnum DotType { get; set; }
        public int DotPrice { get; set; }

        public Partner Partner { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Movement> Movements { get; set; }
    }
}

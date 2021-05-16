using MyAwardProgram.Domain.Aggregates.Partners.Entities;

namespace MyAwardProgram.Domain.Aggregates.Orders.Entities
{
    public class OrderProduct 
    {
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}

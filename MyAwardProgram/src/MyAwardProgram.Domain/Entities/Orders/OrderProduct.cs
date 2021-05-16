using MyAwardProgram.Domain.Entities.Partners;

namespace MyAwardProgram.Domain.Entities.Orders
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

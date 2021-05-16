using MyAwardProgram.Shared.Entities;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Aggregates.Partners
{
    public class Partner : Entity<Partner>
    {
        public string CNPJ { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

using MyAwardProgram.Domain.Aggregates.Partners.Entities;
using MyAwardProgram.Shared.Entities;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Aggregates.Partners.Entities
{
    public class Partner : Entity<Partner>
    {
        public string CNPJ { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

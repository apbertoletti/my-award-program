using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAwardProgram.Domain.Entities.Orders;
using MyAwardProgram.Domain.Entities.Partners;
using System.Collections.Generic;

namespace MyAwardProgram.Data.Maps
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity
                .ToTable("TB_Order");

            entity
                .Property(p => p.Occurrence)
                .IsRequired();
        }
    }
}

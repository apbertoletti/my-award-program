﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAwardProgram.Domain.Aggregates.Orders;
using MyAwardProgram.Domain.Aggregates.Partners;
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

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAwardProgram.Domain.Aggregates.Orders;
using MyAwardProgram.Domain.Aggregates.Partners;

namespace MyAwardProgram.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity
                .ToTable("TB_PartnerProduct");

            entity
                .Property(p => p.SKU)
                .HasMaxLength(16)
                .IsRequired();

            entity
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity
                .HasMany(e => e.Orders)
                .WithMany(e => e.Products)
                .UsingEntity<OrderProduct>(
                    op => op
                        .HasOne(p => p.Order)
                        .WithMany(c => c.OrderProducts)
                        .HasForeignKey(p => p.OrderId),
                    op => op
                        .HasOne(p => p.Product)
                        .WithMany(c => c.OrderProducts)
                        .HasForeignKey(p => p.ProductId),
                    op =>
                    {
                        op.ToTable("TB_OrderProduct");
                        op.HasKey(op => new { op.OrderId, op.ProductId });
                        op.Property(op => op.Quantity).HasDefaultValue(1);
                    });
        }
    }
}

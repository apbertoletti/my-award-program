using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAwardProgram.Domain.Aggregates.Users.Entities;

namespace MyAwardProgram.Data.Maps
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity
                .ToTable("TB_UserAddress");

            entity
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity
                .Property(p => p.Type)
                .IsRequired();

            entity
                .Property(p => p.Description)
                .HasMaxLength(100)
                .IsRequired();

            entity
                .Property(p => p.City)
                .HasMaxLength(60)
                .IsRequired();

            entity
                .Property(p => p.State)
                .HasMaxLength(2)
                .IsRequired();

            entity
                .Property(p => p.Country)
                .HasMaxLength(50)
                .IsRequired();

            entity
                .Property(p => p.ZipCode)
                .HasMaxLength(10)
                .IsRequired();

            entity
                .Property(p => p.UserId)
                .IsRequired();
        }    
    }
}

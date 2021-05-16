using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAwardProgram.Domain.Entities.Partners;

namespace MyAwardProgram.Data.Maps
{
    public class PartnerMap : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> entity)
        {
            entity
                .ToTable("TB_Partner");

            entity
                .Property(p => p.CNPJ)
                .HasMaxLength(14)
                .IsRequired();

            entity
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

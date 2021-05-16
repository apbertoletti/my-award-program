using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAwardProgram.Domain.Aggregates.Movements.Entities;

namespace MyAwardProgram.Data.Maps
{
    public class MovementMap : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> entity)
        {
            entity
                .ToTable("TB_Movement");

            entity
                .Property(p => p.Occurrence)
                .IsRequired();

            entity
                .Property(p => p.Type)
                .IsRequired();

            entity
                .Property(p => p.Dots)
                .IsRequired();

            entity
                .Property(p => p.DueDate)
                .IsRequired();
        }
    }
}

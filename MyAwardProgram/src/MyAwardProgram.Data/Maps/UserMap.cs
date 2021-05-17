using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAwardProgram.Domain.Aggregates.Users.Entities;
using MyAwardProgram.Shared.Types;

namespace MyAwardProgram.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity
                .ToTable("TB_User");

            entity.OwnsOne(x => x.CPF, x =>
            {
                x.Property(s => s.Value)
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsRequired();
            });

            entity.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(p => p.Phone)
                .HasMaxLength(20);

            entity.Property(p => p.Password)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(p => p.Role)                
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAwardProgram.Domain.Aggregates.Users.Entities;

namespace MyAwardProgram.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity
                .ToTable("TB_User");

            entity.Property(p => p.CPF)
                .HasMaxLength(11)
                .IsRequired();

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

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAwardProgram.Domain.Entities.Users;

namespace MyAwardProgram.Data.Maps
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("TB_UserAddress");
        }
    }
}

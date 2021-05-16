using Microsoft.EntityFrameworkCore;
using MyAwardProgram.Domain.Entities.Movements;
using MyAwardProgram.Domain.Entities.Orders;
using MyAwardProgram.Domain.Entities.Partners;
using MyAwardProgram.Domain.Entities.Users;

namespace MyAwardProgram.Data.Contexts
{
    public class AppContextDB : DbContext
    {
        public AppContextDB(DbContextOptions<AppContextDB> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Movement> Movements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContextDB).Assembly);
        }
    }
}

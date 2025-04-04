using Microsoft.EntityFrameworkCore;
using NexusB1.Backend.Models;
using NexusB1.Backend.Models.Configurations;

namespace NexusB1.Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Seller> Sellers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica las configuraciones separadas
            modelBuilder.ApplyConfiguration(new SellerConfiguration());
            // Agrega más configuraciones aquí según sea necesario
        }
    }
}
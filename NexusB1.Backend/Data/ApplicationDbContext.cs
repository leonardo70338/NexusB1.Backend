using Microsoft.EntityFrameworkCore;
using NexusB1.Backend.Models;

namespace NexusB1.Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<InventoryItem> InventoryItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
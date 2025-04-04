using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NexusB1.Backend.Models.Configurations
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            // Configura el índice único para el campo SlpCode
            builder.HasIndex(s => s.SlpCode).IsUnique();
            // Configura el índice único para el campo Email
            builder.HasIndex(s => s.Email).IsUnique();

            // Configura otras propiedades del modelo
            builder.Property(s => s.CommissionPercentage).HasPrecision(4, 2); // Ejemplo: 99.99
        }
    }
}

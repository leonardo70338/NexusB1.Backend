using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace NexusB1.Backend.Models.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            // Configura el índice único para el campo BankCode
            builder.HasIndex(s => s.BankCode).IsUnique();
        }
    }
}

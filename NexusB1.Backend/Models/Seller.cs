using System.ComponentModel.DataAnnotations;

namespace NexusB1.Backend.Models
{
    public class Seller
    {
        // Clave primaria (equivale al campo "SlpCode" en OSLP)
        [Key]
        public int SellerId { get; set; }

        [Required]
        [StringLength(50)]
        public string SlpCode { get; set; }

        // Nombre del vendedor (equivale al campo "SlpName" en OSLP)
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Correo electrónico del vendedor
        [EmailAddress]
        public string Email { get; set; }

        // Teléfono del vendedor
        [Phone]
        public string Phone { get; set; }

        // Comisión del vendedor (porcentaje, equivale al campo "Commision %" en OSLP)
        [Range(0, 100)]
        public decimal CommissionPercentage { get; set; }

        // Estado activo/inactivo del vendedor
        public bool IsActive { get; set; } = true;

        // Serie de facturación electrónica
        public string SerieFEL { get; set; }

        // Fecha de creación del vendedor
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Fecha de nacimiento del vendedor
        public DateTime? BirthDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NexusB1.Backend.Models
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; }

        [Required]
        [StringLength(50)]
        public string BankCode { get; set; }

        [Required]
        [StringLength(100)]
        public string BankName { get; set; }
    }
}

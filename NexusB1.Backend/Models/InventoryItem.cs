using System.ComponentModel.DataAnnotations;

namespace NexusB1.Backend.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}

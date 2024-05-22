using System.ComponentModel.DataAnnotations;

namespace VendingMachine.DataAccess.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [Range(0.01, double.MaxValue)]
        public double Price { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;

namespace VendingMachine.Business.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Name is required!"), MaxLength(128, ErrorMessage = "The name that you have entered is too long!")]
        public required string Name { get; set; }
        [MaxLength(256, ErrorMessage = "The description that you have entered is too long!")]
        public string? Description { get; set; }
        [Required(ErrorMessage ="Price is required!") , Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }
        [Required(ErrorMessage ="Quantity is required!"), Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0")]
        public int Quantity { get; set; }
    }
}
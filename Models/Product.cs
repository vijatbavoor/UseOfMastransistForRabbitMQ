using System.ComponentModel.DataAnnotations;

namespace UseOfMastransistForRabbitMQ.Models
{
    public class Product
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Additional properties for reporting
        public string SKU { get; set; } // Stock Keeping Unit
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        [Required]
        public string Unit { get; set; } // e.g., piece, kg, liter, dugen, pair
        [Required]
        public decimal Cost { get; set; }
        public decimal? Discount { get; set; }
        public int SoldQuantity { get; set; }
        public int ReturnedQuantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastSoldAt { get; set; }
    }
}
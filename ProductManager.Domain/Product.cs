using System.ComponentModel.DataAnnotations;

namespace ProductManager.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public int Rating { get; set; } = 0;
        public ProductStatus InventoryStatus { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }

    public enum ProductStatus
    {
        INSTOCK = 1,
        LOWSTOCK = 2,
        OUTOFSTOCK = 3
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManager.Domain;

namespace ProductManager.Application.Dtos.Products
{
    public class CreateProductRequestDto
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; } = 0;
        public int Rating { get; set; } = 0;
        public ProductStatus InventoryStatus { get; set; } = 0;
    }
}

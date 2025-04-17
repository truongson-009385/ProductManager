using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManager.Application.Dtos.Products;
using ProductManager.Domain;

namespace ProductManager.Application.Mappers
{
    public static class ProductMappers
    {
        public static Product ToModel(this ProductDto product)
        {
            return new Product
            {
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Rating = product.Rating,
                InventoryStatus = product.InventoryStatus,
            };
        }

        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
            {
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Rating = product.Rating,
                InventoryStatus = product.InventoryStatus,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt
            };
        }

        public static Product ToModel(this CreateProductRequestDto dtoRequest)
        {
            return new Product
            {
                Name = dtoRequest.Name,
                Description = dtoRequest.Description,
                Price = dtoRequest.Price,
                Stock = dtoRequest.Stock,
                Rating = dtoRequest.Rating,
                InventoryStatus = dtoRequest.InventoryStatus,
                Code = dtoRequest.Code
            };
        }

        public static Product ToModel(this UpdateProductRequestDto dtoRequest, int id)
        {
            return new Product
            {
                Id = id,
                Name = dtoRequest.Name,
                Description = dtoRequest.Description,
                Price = dtoRequest.Price,
                Stock = dtoRequest.Stock,
                Rating = dtoRequest.Rating,
                InventoryStatus = dtoRequest.InventoryStatus,
                Code = dtoRequest.Code
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManager.Application.Interfaces;
using ProductManager.Domain;

namespace ProductManager.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<Product?> AddAsync(Product product)
        {
            product.Code = GenerateProductCode();
            await _productRepo.AddAsync(product);
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepo.DeleteAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var products = await _productRepo.GetAllAsync();
            return products;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            return product;
        }

        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            await _productRepo.UpdateAsync(id, product);
            return product;
        }

        private string GenerateProductCode()
        {
            var datePart = DateTime.UtcNow.ToString("yyyyMMdd");
            var randomPart = new Random().Next(1000, 9999);
            return $"PROD-{datePart}-{randomPart}";
        }
    }
}

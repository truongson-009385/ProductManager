using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManager.Application.Interfaces;
using ProductManager.Domain;
using ProductManager.Infrastructure.Data;

namespace ProductManager.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> AddAsync(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var existProduct = _context.Products.FirstOrDefault(x => x.Id == id);

            if (existProduct != null)
            {
                _context.Products.Remove(existProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            var existProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

            if (existProduct == null) return null;

            existProduct.Code = product.Code;
            existProduct.Name = product.Name;
            existProduct.Description = product.Description;
            existProduct.Price = product.Price;
            existProduct.Stock = product.Stock;
            existProduct.Rating = product.Rating;
            existProduct.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return existProduct;
        }
    }
}

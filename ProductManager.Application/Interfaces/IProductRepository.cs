﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManager.Domain;

namespace ProductManager.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> AddAsync(Product product);
        Task<Product?> UpdateAsync(int id, Product product);
        Task DeleteAsync(int id);
    }
}

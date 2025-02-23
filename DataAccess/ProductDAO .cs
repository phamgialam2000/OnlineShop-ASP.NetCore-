﻿using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO : SingletonBase<ProductDAO>
    {
        public async Task<IEnumerable<Product>> GetProductAll()
        {
            return await _context.Products.Include(c => c.Category).ToListAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.ProductId == id);
            if (product == null) return null;
            return product;
        }
        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            var existingProduct = await GetProductById(product.CategoryId);
            if (existingProduct != null)
            {
                _context.Entry(existingProduct).CurrentValues.SetValues(product);
            }
            else
            {
                _context.Products.Add(product);

            }
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

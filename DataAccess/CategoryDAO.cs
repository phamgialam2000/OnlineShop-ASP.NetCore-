using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO : SingletonBase<CategoryDAO>
    {
        public async Task<IEnumerable<Category>> GetCategoriesAll()
        {
                return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c =>c.CategoryId == id);
            if (category == null) return null;
            return category;
        }
        public async Task<Category> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<Category> UpdateCategory(Category category)
        {
            var existingCategory = await GetCategoryById(category.CategoryId);
            if (existingCategory != null) { 
            _context.Entry(existingCategory).CurrentValues.SetValues(category);
            }
            else
            {
                _context.Categories.Add(category);

            }
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<bool> DeleteCategory(int id)
        {
            var category = await GetCategoryById(id);
            if (category == null) return false;
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using BusinessObjects;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("api/Category");
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Category>($"api/Category/{id}");
        }
        public async Task AddCategory(Category category)
        {
            await _httpClient.PostAsJsonAsync("api/Category", category);
        }
        public async Task UpdateCategory(Category category)
        {
            await _httpClient.PutAsJsonAsync($"api/Category/{category.CategoryId}", category);
        }

        public async Task DeleteCategory(int id)
        {
            await _httpClient.DeleteAsync($"api/Category/{id}");
        }

        
    }
}

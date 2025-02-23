using BusinessObjects;
using Services.Interfaces;
using ShopDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProduct()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProductDTO>>("api/Product");
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/Product/{id}");
        }
        public async Task AddProduct(Product Product)
        {
            await _httpClient.PostAsJsonAsync("api/Product", Product);
        }
        public async Task UpdateProduct(Product Product)
        {
            await _httpClient.PutAsJsonAsync($"api/Product/{Product.ProductId}", Product);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"api/Product/{id}");
        }

        
    }
}

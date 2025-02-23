using BusinessObjects;
using ShopDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProduct();
        Task<Product> GetProductById(int id);
        Task AddProduct(Product Product);
        Task UpdateProduct(Product Product);
        Task DeleteProduct(int id);
    }
}

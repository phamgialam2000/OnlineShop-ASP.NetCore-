using BusinessObjects;
using DataAccess;
using Repositories.Interface;

namespace Repositories
{
    public class ProductRepository : IProductService
    {
        public async Task<Product> AddProduct(Product product)
        {
            await ProductDAO.Instance.AddProduct(product);
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            await ProductDAO.Instance.DeleteProduct(id);
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await ProductDAO.Instance.GetProductAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await ProductDAO.Instance.GetProductById(id);
        }

        public Task<Product> UpdateProduct(Product product)
        {
            return ProductDAO.Instance.UpdateProduct(product);
        }
    }
}

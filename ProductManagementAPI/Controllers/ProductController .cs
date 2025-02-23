using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductRepository;
        public ProductController(IProductService ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        // GET: ProductController
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _ProductRepository.GetAllProduct();
        }

        // GET: ProductController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var Product = await _ProductRepository.GetProductById(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Product;
        }
        //POST: ProductController/Create
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _ProductRepository.AddProduct(product);
            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }
        // PUT: ProductController/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            var temp = await _ProductRepository.GetProductById(id);
            if (temp == null)
            {
                return NotFound();
            }
            product.ProductId = id;
            await _ProductRepository.UpdateProduct(product);
            return Content("Update success");
        }
        // DELETE: ProductController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var Product = await _ProductRepository.GetProductById(id);
            if (Product == null)
            {
                return NotFound();
            }
            await _ProductRepository.DeleteProduct(id);
            return Content("Delete success");
        }

    }
        
}

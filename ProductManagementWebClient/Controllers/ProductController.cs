using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Interfaces;

namespace ProductManagementWebClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var product = await _productService.GetAllProduct();
            return View(product);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _productService.GetProductById(id);
            return View(product);
        }

        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {
            var category = await _categoryService.GetAllCategories();
            ViewData["CategoryId"] = new SelectList(category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _productService.GetProductById(id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _productService.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);

        }


        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Product product)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View(product);
            }

        }
    }
}
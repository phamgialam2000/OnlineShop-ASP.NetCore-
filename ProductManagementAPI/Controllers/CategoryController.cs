using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: CategoryController
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.GetAllCategory();
        }

        // GET: CategoryController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }
        //POST: CategoryController/Create
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _categoryRepository.AddCategory(category);
            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }
        // PUT: CategoryController/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            var temp = await _categoryRepository.GetCategoryById(id);
            if (temp == null)
            {
                return NotFound();
            }
            category.CategoryId = id;
            await _categoryRepository.UpdateCategory(category);
            return Content("Update success");
        }
        // DELETE: CategoryController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            await _categoryRepository.DeleteCategory(id);
            return Content("Delete success");
        }

    }
        
}

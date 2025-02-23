using BusinessObjects;
using DataAccess;
using Repositories.Interface;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<Category> AddCategory(Category category)
        {
            await CategoryDAO.Instance.AddCategory(category);
            return category;
        }

        public async Task DeleteCategory(int id)
        {
            await CategoryDAO.Instance.DeleteCategory(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await CategoryDAO.Instance.GetCategoriesAll();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await CategoryDAO.Instance.GetCategoryById(id);
        }

        public Task<Category> UpdateCategory(Category category)
        {
            return CategoryDAO.Instance.UpdateCategory(category);
        }
    }
}

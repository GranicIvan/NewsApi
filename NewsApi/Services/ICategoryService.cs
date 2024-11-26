using NewsApi.Model.Models;

namespace NewsApi.Services
{
    public interface ICategoryService
    {

        public List<Category> GetAllCategories();

        public Task<IEnumerable<Category>> GetAllCategoriesAsync();


        //public Task AddCategoryAsync(Category category);

        
    }
}

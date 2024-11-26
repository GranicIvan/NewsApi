using NewsApi.Model.Models;
using NewsApi.Data.UnitOfWork;

namespace NewsApi.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        private UnitOfWork unitOfWork;

        public CategoryService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Category> GetAllCategories()
        {
            return unitOfWork.CategoryRepository.GetAll().ToList();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await unitOfWork.CategoryRepository.GetAllAsync();
        }
    }
}

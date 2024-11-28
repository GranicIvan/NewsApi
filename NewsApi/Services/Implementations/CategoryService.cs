using NewsApi.Model.Models;
using NewsApi.Data.UnitOfWork;

namespace NewsApi.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        private UnitOfWork _unitOfWork;

        public CategoryService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            return _unitOfWork.CategoryRepository.GetAllAsync();
        }

        public Task<Category> GetById(int id)
        {
            return _unitOfWork.CategoryRepository.GetByIdAsync(id);
        }

  

    }
}

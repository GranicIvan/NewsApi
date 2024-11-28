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

        public async Task<Category?> AddAsync(Category category)
        {
            try
            {
             

                await _unitOfWork.CategoryRepository.AddAsync(category);
                _unitOfWork.Save();

            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"Adding Category faild. {ex.Message}");
                category = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Adding Category faild. {ex.Message}");
                category = null;
            }
            
            return category;
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

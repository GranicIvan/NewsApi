using NewsApi.Model.Models;
using NewsApi.Data.UnitOfWork;
using NewsApi.Model.DTO;
using AutoMapper;

namespace NewsApi.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Category?> AddAsync(CategoryDTO categoryDTO)
        {
            Category? category = null;
            try
            {

                 category =  _mapper.Map<Category>(categoryDTO);                

            

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

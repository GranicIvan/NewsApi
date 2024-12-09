using NewsApi.Model.Models;
using NewsApi.Data.UnitOfWork;
using NewsApi.Model.DTO;
using AutoMapper;
using NewsApi.Controllers;
using Serilog;


namespace NewsApi.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Serilog.ILogger _logger;

        public CategoryService(UnitOfWork unitOfWork, IMapper mapper, Serilog.ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Category?> AddAsync(CategoryDTO categoryDTO)
        {
            Category? category = null;
            try
            {
                 category =  _mapper.Map<Category>(categoryDTO);                            

                await _unitOfWork.CategoryRepository.AddAsync(category);
                await _unitOfWork.SaveAsync();

            }
            catch (OperationCanceledException ex)
            {               
                _logger.Error(ex, "An error occurred while adding Category.");
                Console.WriteLine($"Adding Category faild. {ex.Message}");
                category = null;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error occurred while adding Category.");
                Console.WriteLine($"Adding Category faild. {ex.Message}");
                category = null;
            }
            
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _unitOfWork.CategoryRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(CategoryDTO category)
        {
            _unitOfWork.CategoryRepository.Update(_mapper.Map<Category>(category));
            return await _unitOfWork.SaveAsync();
        }
    }
}

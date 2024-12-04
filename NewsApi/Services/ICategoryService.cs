using NewsApi.Model.DTO;
using NewsApi.Model.Models;

namespace NewsApi.Services
{
    public interface ICategoryService
    {

        public Task<Category> GetById(int id);

        public Task<IEnumerable<Category>> GetAllAsync();

        public Task<Category?> AddAsync(CategoryDTO category);


        public Task<int> UpdateAsync(CategoryDTO category);


    }
}

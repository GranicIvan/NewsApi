using NewsApi.Model.Models;

namespace NewsApi.Services
{
    public interface ICategoryService
    {

        

        public Task<Category> GetById(int id);

        public Task<IEnumerable<Category>> GetAllAsync();




    }
}

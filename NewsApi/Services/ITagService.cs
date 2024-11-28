using NewsApi.Model.Models;

namespace NewsApi.Services
{
    public interface ITagService
    {
        public Task<IEnumerable<Tag>> GetAllAsync();
        Task<Tag> GetById(int id);

        Task<Tag?> AddAsync(Tag tag);
    }
}

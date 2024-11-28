using NewsApi.Data.UnitOfWork;
using NewsApi.Model.Models;

namespace NewsApi.Services.Implementations
{
    public class TagService : ITagService
    {
        private UnitOfWork _unitOfWork;

        public TagService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Tag>> GetAllAsync()
        {
            return _unitOfWork.TagRepository.GetAllAsync();
        }

        public Task<Tag> GetById(int id)
        {
            return _unitOfWork.TagRepository.GetByIdAsync(id);
        }
    }
}

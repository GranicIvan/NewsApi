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

        public async Task<Tag?> AddAsync(Tag tag)
        {
            try
            {
                await _unitOfWork.TagRepository.AddAsync(tag);
                _unitOfWork.Save();
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"Adding Tag faild. {ex.Message}");
                tag = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Adding Tag faild. {ex.Message}");
                tag = null;
            }

            return tag;
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

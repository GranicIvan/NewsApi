using AutoMapper;
using NewsApi.Data.UnitOfWork;
using NewsApi.Model.DTO;
using NewsApi.Model.Models;

namespace NewsApi.Services.Implementations
{
    public class TagService : ITagService
    {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly Serilog.ILogger _logger;

        public TagService(UnitOfWork unitOfWork, IMapper mapper, Serilog.ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Tag?> AddAsync(TagDTO tagDTO)
        {
            Tag? tag = null;
            try
            {
                tag = _mapper.Map<Tag>(tagDTO); 
                await _unitOfWork.TagRepository.AddAsync(tag);
                await _unitOfWork.SaveAsync();
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

        public async Task<int> UpdateAsync(TagDTO tag)
        {
            _unitOfWork.TagRepository.Update(_mapper.Map<Tag>(tag));
            return await _unitOfWork.SaveAsync();
        }
    }
}

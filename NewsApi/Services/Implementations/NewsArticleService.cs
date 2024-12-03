using AutoMapper;
using NewsApi.Data.UnitOfWork;
using NewsApi.Model.DTO;
using NewsApi.Model.Enums;
using NewsApi.Model.Models;

namespace NewsApi.Services.Implementations
{
    public class NewsArticleService : INewsArticleService
    {

        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public NewsArticleService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<NewsArticleDTO> AddAsync(NewsArticleDTO newsArticleDTO)
        {
            NewsArticle? newsArticle = null;
            try
            {

                newsArticle = _mapper.Map<NewsArticle>(newsArticleDTO);

                if (newsArticleDTO.Category != null) 
                {
                    newsArticle.Category = await _unitOfWork.CategoryRepository.GetByIdAsync(newsArticleDTO.Category.Id);
                }

                   

                if (newsArticleDTO.Tags?.Any() ?? false)
                {
                    newsArticle.Tags = await _unitOfWork.TagRepository.GetAllTagsByID(newsArticleDTO.Tags.Select(t => t.Id));
                }

                await _unitOfWork.NewsArticleRepository.AddAsync(newsArticle);
                await _unitOfWork.SaveAsync();
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"Adding NewsArticle faild. {ex.Message}");
                newsArticle = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Adding NewsArticle faild. {ex.Message}");
                newsArticle = null;
            }

            return _mapper.Map<NewsArticleDTO>( newsArticle);

        }

        public Task<IEnumerable<NewsArticle>> getAllNewsArticlesAsync()
        {
            return _unitOfWork.NewsArticleRepository.GetAllAsync();
        }

        public Task<NewsArticle> GetNewsArticleById(int id)
        {
            return _unitOfWork.NewsArticleRepository.GetByIdAsync(id);
        }

        public Task<NewsArticle> GetNewsArticleByName(string name)
        {
            return _unitOfWork.NewsArticleRepository.GetByNameAsync(name);
        }

        public Task<int> DeleteNewsArticle(int id)
        {
            return _unitOfWork.NewsArticleRepository.DeleteAsync(id);
        }

        public async Task<int> UpdateNewsArticle(NewsArticleDTO newsArticleDTO)
        {
            NewsArticle newsArticle = _mapper.Map<NewsArticle>(newsArticleDTO);


            if (newsArticle.Category != null)
            {
                newsArticle.Category =  await _unitOfWork.CategoryRepository.GetByIdAsync(newsArticle.Category.Id) ;
            }

            if (newsArticleDTO.Tags?.Any() ?? false)
            {
                newsArticle.Tags = await _unitOfWork.TagRepository.GetAllTagsByID(newsArticleDTO.Tags.Select(t => t.Id));
            }

            _unitOfWork.NewsArticleRepository.Update(_mapper.Map<NewsArticle>(newsArticle));
            return await _unitOfWork.SaveAsync(); 
        }

        public Task<IEnumerable<NewsArticle>> getActiveNewsArticlesAsync()
        {
            return _unitOfWork.NewsArticleRepository.GetActiveNewsArticlesAsync();
        }

        public Task<IEnumerable<NewsArticle>> GetNewsArticleByStatus(Status status)
        {
            return _unitOfWork.NewsArticleRepository.GetNewsArticleByStatus(status);
        }
    }
}

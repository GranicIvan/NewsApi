using AutoMapper;
using NewsApi.Data.UnitOfWork;
using NewsApi.Model.DTO;
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
                //newsArticle.Category = _unitOfWork.CategoryRepository.GetById( newsArticle.Category.Id );
                //Sta raditi ako kategorija ne postoji

                newsArticle = _mapper.Map<NewsArticle>(newsArticleDTO);

                newsArticle.Category = await _unitOfWork.CategoryRepository.GetByIdAsync( newsArticleDTO.Category.Id );

                if (newsArticleDTO.Tags?.Any() ?? false)
                {
                    newsArticle.Tags = await _unitOfWork.TagRepository.GetAllTagsByID(newsArticleDTO.Tags.Select(t => t.Id));
                }

                await _unitOfWork.NewsArticleRepository.AddAsync(newsArticle);
                _unitOfWork.Save();
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
    }
}

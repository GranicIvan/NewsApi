using AutoMapper;
using Microsoft.AspNetCore.Mvc.Routing;
using NewsApi.Helpers;
using NewsApi.Model.DTO;
using NewsApi.Model.Models;
using NewsApi.Services;

namespace NewsApi.Configurations.Mapper
{
    public class AutoMapperProfiles : Profile
    {

        private readonly INewsArticleService _newsArticleService;

        public AutoMapperProfiles(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>().ForMember(cat => cat.Description, m => m.MapFrom( (src, dest)  =>
            {
                if (string.IsNullOrWhiteSpace(src.Description))
                {
                    return "Description is empty";
                }
                return src.Description;
            })
            );
            CreateMap<Tag, TagDTO>();
            CreateMap<TagDTO, Tag>().ForMember(tag => tag.Description, m => m.MapFrom( (src, des) =>
            {
                if (string.IsNullOrWhiteSpace(src.Description)) 
                {
                    return "Description is empty";
                }
                return src.Description;

            })
            );
            CreateMap<NewsArticle, NewsArticleDTO>().ForMember(dest => dest.Tags , m => m.MapFrom( (src, des) =>
            {
                List<Tag> tags = new List<Tag>();
                if(src.Tags?.Any() ?? false) 
                {
                    foreach (var tag in src.Tags) {
                        tag.Articles = null;
                        tags.Add(tag);
                    }
                }
                return tags;
            }
            ) ).ForMember(dest => dest.Image, m => m.MapFrom((src, des) =>
            {   
                if(string.IsNullOrWhiteSpace(src?.ImageUrl))
                {
                    return string.Empty;
                }

                return ImageConversionHelper.ConvertImageToBase64(src.ImageUrl);
            }
            ));
            CreateMap<NewsArticleDTO, NewsArticle>();
           
        }


    }
}

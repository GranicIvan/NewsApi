using AutoMapper;
using NewsApi.Model.DTO;
using NewsApi.Model.Models;

namespace NewsApi.Configurations.Mapper
{
    public class AutoMapperProfiles : Profile
    {
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
            ) );
            CreateMap<NewsArticleDTO, NewsArticle>();

        }


    }
}

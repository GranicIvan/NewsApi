using NewsApi.Services.Implementations;
using NewsApi.Services;
using NewsApi.Data.UnitOfWork;

namespace NewsApi.Configurations.Extensions
{
    public static class ServiceLoader
    {

        public static void AddCustomServices(this IServiceCollection services)
        {   
            services.AddScoped<UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>(); //singlton vs scoped vs transient
            services.AddScoped<INewsArticleService, NewsArticleService>();
            services.AddScoped<ITagService, TagService>();

        }

    }
}

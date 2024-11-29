using NewsApi.Services.Implementations;
using NewsApi.Services;
using NewsApi.Data.UnitOfWork;
using NewsApi.Data.Base;
using Microsoft.EntityFrameworkCore;
using NewsApi.Model.Models;
using NewsApi.Model.DTO;
using Microsoft.Extensions.DependencyInjection;

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

        public static void AddDatabase(this IServiceCollection services, ConfigurationManager configuration ) 
        {
            string connectionsString = "Database";

            if (Environment.MachineName.Equals("DESKTOP-SB6TAM2"))
            {
                connectionsString = "DatabaseLaptop";
            }

            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString(connectionsString)));
        }


    }
}

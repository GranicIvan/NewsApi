using NewsApi.Services.Implementations;
using NewsApi.Services;
using NewsApi.Data.UnitOfWork;

namespace NewsApi.Configurations.Extenders
{
    public static class ServiceLoader
    {

        public static void AddCustomServices(this IServiceCollection services)
        {   
            services.AddScoped<UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>(); //singlton vs scoped vs transient
           


        }

    }
}

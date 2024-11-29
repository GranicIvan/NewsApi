using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NewsApi.Configurations.Mapper;
namespace NewsApi.Configurations.Extensions
{
    public static class AutoMapperExtensions
    {

        public static void AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles));
        }
    }
}

using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace NewsApi.Configurations.Extensions
{
    public static class VersioningExtensions
    {
        public static void AddVersionsing(this IServiceCollection services)
        {

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
               
              
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

        }

       

    }
}

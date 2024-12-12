﻿namespace NewsApi.Configurations.Extensions
{
    public static class AddCorsExtensions
    {

        public static void AddCumstomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });
        }
    }
}

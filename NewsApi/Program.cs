
using Microsoft.EntityFrameworkCore;
using NewsApi.Configurations.Extenders;
using NewsApi.Data.Base;
using NewsApi.Data.UnitOfWork;
using NewsApi.Services;
using NewsApi.Services.Implementations;

namespace NewsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json");

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

            //builder.Services.AddScoped<NewsArticleRepo>(); // Add scoped vs addTransient vs addSingleton
            // //builder.Services.addCustomServices - ja napravio ovu extendovanu metodu


            //builder.Services.AddScoped<UnitOfWork>();
            builder.Services.AddCustomServices(); // OVDE PUKNE
            //builder.Services.AddSingleton<ICategoryService, CategoryService>();// i ovde pukne

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

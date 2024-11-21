using Microsoft.EntityFrameworkCore;
using NewsApi.Model.Models;

namespace NewsApi.Data.Base
{
    internal class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}

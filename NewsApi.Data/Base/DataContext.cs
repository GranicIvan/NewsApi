using Microsoft.EntityFrameworkCore;
using NewsApi.Model.Models;

namespace NewsApi.Data.Base
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        //protected override void OnModelCreating(ModelBuilder mb ) 
        //{

        //    //mb.Entity<NewsArticle>().HasMany(x =>x.Tags).WithMany(x => x.Articles);
            
        //}

    }
}

using BlogÖdev.Models.Entities;
using Microsoft.EntityFrameworkCore;
using BlogÖdev.ViewModels.Article;

namespace BlogÖdev.Models.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User(1, "Emirhan", "12345"));
            modelBuilder.Entity<Article>().Property(x => x.CreatedTime).HasDefaultValueSql("getutcdate()");
        }

        public DbSet<BlogÖdev.ViewModels.Article.ArticleViewModel> ArticleViewModel { get; set; }

        public DbSet<BlogÖdev.ViewModels.Article.UpdateViewModel> UpdateViewModel { get; set; }
    }
}

using Blog.Application.Interfaces;
using Blog.Domain;
using Blog.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class BlogDbContext : DbContext, IBlogDbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options) { }

        /// <summary>
        /// Коллекция категорий
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        /// <summary>
        /// Коллекция статей
        /// </summary>
        public DbSet<Entity> Entities { get; set; }
        /// <summary>
        /// Коллекция отзывов
        /// </summary>
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new EntryConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

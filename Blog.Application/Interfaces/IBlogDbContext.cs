using Blog.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Interfaces
{
    /// <summary>
    /// Интерфейс контекста базы данных
    /// </summary>
    public interface IBlogDbContext
    {
        /// <summary>
        /// Коллекция категорий
        /// </summary>
        DbSet<Category> Categories { get; set; }
        /// <summary>
        /// Коллекция статей
        /// </summary>
        DbSet<Entity> Entities { get; set; }
        /// <summary>
        /// Коллекция отзывов
        /// </summary>
        DbSet<Review> Reviews { get; set; }

        /// <summary>
        /// Метод сохранения данных в базы данных
        /// </summary>
        /// <param name="cancellationToken">токен отмены операции</param>
        /// <returns>результат операции</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

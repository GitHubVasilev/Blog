using Blog.Domain.Base;

namespace Blog.Domain
{
    /// <summary>
    /// Модель сущности пост
    /// </summary>
    public class Entry : Auditable
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// Содержимое
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// Флаг отображения
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Список комментариев
        /// </summary>
        public List<Review> Reviews { get; set; } = null!;
        /// <summary>
        /// Идентификатор категории которой принадлежит статья
        /// </summary>
        public Guid CategoryId { get; set; }
    }
}

using Blog.Domain.Base;

namespace Blog.Domain
{
    /// <summary>
    /// Модель сущности комментарий
    /// </summary>
    public class Review : Auditable
    {
        /// <summary>
        /// Текст комментария
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// Статья к которой комментарий принадлежит
        /// </summary>
        public Guid EntryId { get; set; } 
        /// <summary>
        /// Идентификатор родительского комментария
        /// </summary>
        public Guid ParentReviewId { get; set; }
        /// <summary>
        /// Флаг видимости
        /// </summary>
        public bool IsVisible { get; set; }
    }
}

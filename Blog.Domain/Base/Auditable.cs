namespace Blog.Domain.Base
{
    /// <summary>
    /// Абстрактный класс с данными создания и обновления
    /// </summary>
    public class Auditable : Identity, IAuditable
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Автор
        /// </summary>
        public string CreatedBy { get; set; } = null!;
        /// <summary>
        /// Дата последнего обновления
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// Редактор
        /// </summary>
        public string? UpdatedBy { get; set; }
    }
}

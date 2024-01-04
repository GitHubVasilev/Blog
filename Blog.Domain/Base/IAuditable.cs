namespace Blog.Domain.Base
{
    /// <summary>
    /// Интерфейс для сущностей для с данными о создании и обновлении
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Автор
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Дата обновления
        /// </summary>
        DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Редактор
        /// </summary>
        string? UpdatedBy { get; set; }
    }
}

using Blog.Domain.Base;

namespace Blog.Domain
{
    /// <summary>
    /// Модель типа данных Категория
    /// </summary>
    public class Category : Identity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Описание 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Флаг видимости
        /// </summary>
        public bool Visible { get; set; } = false;
        /// <summary>
        /// Идентификатор родительской категории
        /// </summary>
        public Guid ParentId { get; set; }
        /// <summary>
        /// Список статей в категории
        /// </summary>
        public List<Entry>? Entries { get; set; }
    }
}

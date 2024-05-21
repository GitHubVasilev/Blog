using Blog.Domain.Base;

namespace Blog.Domain
{
    /// <summary>
    /// Модель типа данных Категория
    /// </summary>
    public class Category : Identity, IModelTree
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
        public bool IsVisible { get; set; } = false;
        /// <summary>
        /// Идентификатор родительской категории
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Список статей в категории
        /// </summary>
        public List<Entity>? Entries { get; set; }
    }
}

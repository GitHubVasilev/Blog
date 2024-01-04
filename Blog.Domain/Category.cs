namespace Blog.Domain
{
    /// <summary>
    /// Модель типа данных Категория
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Uid { get; set; }
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
    }
}

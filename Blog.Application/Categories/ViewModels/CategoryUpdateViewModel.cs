using Blog.Application.Interfaces;

namespace Blog.Application.Categories.ViewModels
{
    /// <summary>
    /// Модель представления сущности Категория для обновления данных
    /// </summary>
    public class CategoryUpdateViewModel : ViewModelBase
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
        public bool IsVisible { get; set; }
        /// <summary>
        /// Родительская категория
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}

using Blog.Application.Interfaces;

namespace Blog.Application.Categories.ViewModels
{
    /// <summary>
    /// Модель представления для создания категории
    /// </summary>
    public class CategoryCreateViewModel : ViewModelBase
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
        /// Идентификатор родительской категория
        /// </summary>
        public Guid? ParentCategoryId { get; set; }
    }
}

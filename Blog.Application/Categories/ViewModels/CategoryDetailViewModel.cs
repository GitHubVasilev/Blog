using Blog.Application.Interfaces;

namespace Blog.Application.Categories.ViewModels
{
    /// <summary>
    /// Детальное отображение категории
    /// </summary>
    public class CategoryDetailViewModel : ViewModelBase
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
        /// Количество дочерних категорий
        /// </summary>
        public int CountChildren { get; set; }
        /// <summary>
        /// Родительская категория
        /// </summary>
        public CategoryDetailViewModel? Parent { get; set; }
        /// <summary>
        /// Список дочерних категорий
        /// </summary>
        public List<CategoryDetailViewModel> Children { get; set; } = null!;
    }
}

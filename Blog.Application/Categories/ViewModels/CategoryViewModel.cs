using Blog.Application.Interfaces;

namespace Blog.Application.Categories.ViewModels
{
    /// <summary>
    /// Общая модель представления для сущности Категория
    /// </summary>
    public class CategoryViewModel : ViewModelBase, ITree<CategoryViewModel>
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
        /// Список дочерних категорий
        /// </summary>
        public List<CategoryViewModel> Child { get; set; } = null!;
        /// <summary>
        /// Родительская категория
        /// </summary>
        public CategoryViewModel? Parent { get; set; }
    }
}

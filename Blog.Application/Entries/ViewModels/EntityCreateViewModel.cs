using Blog.Application.Interfaces;

namespace Blog.Application.Entries.ViewModels
{
    /// <summary>
    /// Модель представления для создания сущности Пост
    /// </summary>
    public class EntityCreateViewModel : ViewModelBase
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// Контент
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// Флаг видимости
        /// </summary>
        public bool IsVisible { get; set; }
    }
}
